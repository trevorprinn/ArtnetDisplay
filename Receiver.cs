using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArtnetDisplay {
    class Receiver : IDisposable {
        private UdpClient _client;
        private bool _close;
        private bool _closed;
        private static byte[] _artnetHeader;

        public class PacketReceivedEventArgs {
            public byte[] Data { get; }
            public IPEndPoint Ep { get; }
            public PacketReceivedEventArgs(byte[] data, IPEndPoint ep) {
                Data = data;
                Ep = ep;
            }
        }
        public event EventHandler<PacketReceivedEventArgs> PacketReceived;

        static Receiver() {
            _artnetHeader = new byte[8];
            Encoding.UTF8.GetBytes("Art-Net").CopyTo(_artnetHeader, 0);
            _artnetHeader[7] = 0;
        }

        public Receiver(int port = 0x1936) {
            _client = new UdpClient(port);
            _client.Client.ReceiveTimeout = 1000;

            Task.Run(() => receive());
        }

        private void receive() {
            while (!_close) {
                IPEndPoint ep = null;
                byte[] data = null;
                try {
                    data = _client.Receive(ref ep);
                } catch (SocketException) {
                    // Assume it's a timeout
                    if (!_close) continue;
                }
                if (_close) break;
                decode(data, ep);
            }
            try {
                _client.Close();
            } finally {
                _closed = true;
            }
        }

        private void decode(byte[] packet, IPEndPoint ep) {
            if (packet == null || packet.Length < 18) return; // Can't be an Artnet packet
            if (_artnetHeader.Zip(packet, (h, p) => h != p).Any(m => m)) return; // Not an Artnet header
            var opcode = (packet[9] << 8) + packet[8];
            if (opcode != 0x5000) return; // Only processing OpOutput packets.
            var universe = (packet[15] << 8) + packet[14];
            if (universe != 0) return;
            // Not checking sequence at the moment.
            var dataLength = (packet[16] << 8) + packet[17];
            if (packet.Length != dataLength + 18) return; // Malformed packet
            var data = packet.Skip(18).ToArray();
            OnPacketReceived(data, ep);
        }

        protected virtual void OnPacketReceived(byte[] data, IPEndPoint ep) {
            PacketReceived?.Invoke(this, new PacketReceivedEventArgs(data, ep));
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    _close = true;
                    while (!_closed) Thread.Sleep(10);
                }

                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(true);
        }
        #endregion

    }
}
