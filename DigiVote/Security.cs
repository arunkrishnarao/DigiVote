using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace DigiVote
{
    public partial class Security : Form
    {   
        string secKey;
        string exitKey;
        public Security(string securityKey, string exitKey_)
        {
            InitializeComponent();
            secKey = securityKey;
            exitKey = exitKey_;
        }

        private void Form4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == secKey)
            {
                this.Close();
            }
            if (e.KeyChar.ToString() == exitKey)
            {
                if (MessageBox.Show(" Are you sure to want to end the election?", " Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Form ss = new Result();
                    ss.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
