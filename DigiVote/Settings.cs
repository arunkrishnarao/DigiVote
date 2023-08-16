using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Net.Sockets;
using static System.Collections.Specialized.BitVector32;

namespace DigiVote
{
    public partial class Settings : Form
    {
        bool nota = false, symbol = false;
        string secKey, exitKey;

        public Settings()
        {
            InitializeComponent();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Elections election = Globals.Election;

            symbol = checkBox2.Checked;
            nota = checkBox3.Checked;
            exitKey = textBox1.Text;
            secKey = textBox2.Text;

            if (MessageBox.Show(" Are you sure want to start the election?", " Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Form ss3 = new BallotForm(nota, symbol, secKey, exitKey);
                this.Hide();
                Form ss5 = new Background();
                ss5.Show();
                ss3.ShowDialog();
                ss5.Close();
                this.Show();
            }
        }
    }
}
