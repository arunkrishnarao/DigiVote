using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;



namespace DigiVote
{
    public partial class DigiVote : Form
    {
        private static Int64 candidate_cntr;
        private static String title;
        private static decimal count;
        private static List<String> candidate = new List<String>();
        private static List<Image> symbol = new List<Image>();

        bool symbols_enabled;
        static string path1 = Directory.GetCurrentDirectory();
        string imgLoc = "";

        private void panel3_Click(object sender, EventArgs e)
        {
            Form ss = new Instructions();
            ss.Show();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (candidate_cntr == count)
            {
                Form ss5 = new Settings();
                ss5.ShowDialog();
            }
            else
            {
                MessageBox.Show(" Please add all of the candidates", " Error");
            }
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            panel7.Hide();
            panel18.Show();
        }

        // Save Election
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text !=null)
            {
                title = textBox3.Text;
                count = numericUpDown1.Value;
                symbols_enabled = checkBox1.Checked;

                if (candidate_cntr < count)
                    textBox4.Enabled = true;
                if (symbols_enabled)
                {
                    button6.Enabled = true;
                }
                button3.Enabled = false;
                checkBox1.Enabled = false;
                numericUpDown1.Enabled = false;
            }
            else
            {
                MessageBox.Show(" Invalid Election Title, Election Title cannot be <null>.", " Error");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Select Candidate Symbol";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    pictureBox7.ImageLocation = imgLoc;
                    button8.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                button8.Enabled = false;
            }

        }

        // Save Candidate
        private void button8_Click(object sender, EventArgs e)
        {
            if (candidate_cntr < count)
            {
                try
                {
                    candidate.Add(textBox4.Text);
                    if (symbols_enabled == true)
                    {
                        symbol.Add(Image.FromFile(imgLoc));
                    }

                    MessageBox.Show(" Candidate Added", " Sucess");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                textBox4.Enabled = true;
                textBox4.Text = "";
                pictureBox7.Image = null;
            }
            if (candidate_cntr == count-1)
            {
                MessageBox.Show(" Candidate Limit Reached. You can now start the election.", " Note");
                textBox4.Enabled = false;
                button8.Enabled = false;
                pictureBox7.Image = null;

                Globals.Election = new Elections(title, candidate_cntr + 1, candidate, symbol);
            }
            candidate_cntr++;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button8.Enabled = true;
        }

        private void panel20_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public DigiVote()
        {
            try
            {
                path1 = path1 + "";
                InitializeComponent();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form ss2 = new About();
            ss2.Show();
        }

        private void DigiVote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void DigiVote_Load(object sender, EventArgs e)
        {
            panel7.Show();
            panel18.Hide();
        }

        private void panel15_Click(object sender, EventArgs e)
        {
            panel7.Show();
            panel18.Hide();
        }
    }
}
