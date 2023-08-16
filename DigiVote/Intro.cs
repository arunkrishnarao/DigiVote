using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DigiVote
{

    public partial class Intro : Form
    {
        int t;
        public Intro()
        {
            InitializeComponent();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            t++;
            if (t == 2)
            {
                Form transit = new DigiVote();
                transit.Show();
                this.Hide();
            }
        }

        private void Intro_Load(object sender, EventArgs e)
        {
            var exists = System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1;
            if (exists == true)
            {
                MessageBox.Show("Another instance of the program is already running.", " Error");
                if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1) System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

    }
}
