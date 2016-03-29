using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtnetDisplay {
    public partial class FormMain : Form {
        private Receiver _receiver = new Receiver();
        private DateTime _lastTick = DateTime.Now.AddMinutes(-1);

        public FormMain() {
            InitializeComponent();
            CreateHandle();
            var col = new DataGridViewBarColumn();
            col.DataPropertyName = "Value";
            dataDmx.Columns.Add(col);
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _receiver.PacketReceived += packetReceived;
        }

        private void packetReceived(object sender, Receiver.PacketReceivedEventArgs e) {
            if (InvokeRequired) {
                BeginInvoke(new EventHandler<Receiver.PacketReceivedEventArgs>(packetReceived), sender, e);
                return;
            }

            int chan = 1;
            dataDmx.DataSource = e.Data.Select(v => new { Channel = chan++, Value = v }).ToArray();
            labelIP.Text = e.Ep.Address.ToString();
            _lastTick = DateTime.Now;
            light.Invalidate();
        }

        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);
            _receiver.Dispose();
            _receiver = null;
        }

        private void timerTick_Tick(object sender, EventArgs e) {
            light.Invalidate();
        }

        private void light_Paint(object sender, PaintEventArgs e) {
            var brush = DateTime.Now.Subtract(_lastTick).TotalMilliseconds > 2000 ? Brushes.Red : Brushes.Green;
            e.Graphics.FillEllipse(brush, light.ClientRectangle);
        }
    }
}
