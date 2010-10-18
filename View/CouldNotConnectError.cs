using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WatchCommunication;

namespace View
{
    public partial class CouldNotConnectError: Form
    {
        private IAccessPoint accessPoint;
        public CouldNotConnectError(IAccessPoint accessPoint) {
            this.accessPoint = accessPoint;
            InitializeComponent();
        }

        private void retryButton_Click(object sender, EventArgs e) {
            try {
                accessPoint.Open();
                this.Hide();
            }
            catch {
                MessageBox.Show("Still cannot connect.",
                    "Cannot Connect",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void continueButton_Click(object sender, EventArgs e) {
            this.Hide();
        }
    }

}
