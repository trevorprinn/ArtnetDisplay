using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtnetDisplay {
    partial class FormAbout : Form {
        public FormAbout() {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;

            var links = new List<Link>();
            string desc = AssemblyDescription + "\r\n\r\n";
            desc += "Artnet Display is included in ";
            links.Add(new Link("MobileDMX", "http://mobiledmx.com", ref desc));
            desc += "\r\n\r\nSource is available from ";
            links.Add(new Link("GitHub", "https://github.com/trevorprinn/ArtnetDisplay", ref desc));

            labelDesc.Text = desc;
            foreach (var l in links) l.Add(labelDesc);
        }

        private class Link {
            public int Start { get; private set; }
            public int Length { get; private set; }
            public string Url { get; private set; }

            public Link(string linkText, string url, ref string text) {
                Start = text.Length;
                Length = linkText.Length;
                Url = url;
                text += linkText;
            }

            public void Add(LinkLabel lbl) {
                lbl.Links.Add(Start, Length, Url);
            }
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0) {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "") {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion {
            get {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void labelDesc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string url = e.Link.LinkData.ToString();
            System.Diagnostics.Process.Start(url);
        }
    }
}
