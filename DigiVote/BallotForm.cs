using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace DigiVote
{
    public partial class BallotForm : Form
    {
        Elections election = Globals.Election;
        List<String> candidates;
        List<Image> symbols;
        List<double> votes;
        List<Button> voteButtons = new List<Button>();
        Int64 count;
        Int64 totalVotes = 0;
        String secKey, exitKey;
        bool notaEnabled, symbolEnabled;
        string electionTitle;
        int s = 0, m = 0, h = 0;

        public BallotForm(bool nota, bool symbol, string sec, string exit)
        {
            count = election.getCount();
            notaEnabled = nota;
            if (notaEnabled == true)
            {
                votes = new List<double>(new double[(int)count + 1]);
            }
            else
            {
                votes = new List<double>(new double[(int)count]);
            }

            symbolEnabled = symbol;
            candidates = election.getCandidates();
            symbols = election.getSymbols();
            electionTitle = election.getTitle();
            secKey = sec;
            exitKey = exit;

            Globals.Results = new Results(votes, totalVotes, notaEnabled);
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label22.Text = "" + electionTitle;
            label16.Text = 0 + " Minutes";

            label19.Text = "Ready to Vote!";
            label20.Text = "" + totalVotes;

            int buttonLength = 150;
            int buttonHeight = 50;

            int symbolLength = 100;
            int symbolHeight = 100;

            int textLength = 100;
            int textHeight = 20;

            int lineSpacing = 110;

            int x = 0;
            int y = 0;
            int i = 0;

            for(i = 0; i < (int) count; i++)
            {
                Label label = new Label();
                label.Size = new Size(textLength, textHeight);
                label.Name = "candidate_label_" + i;
                label.Text = candidates[i];
                label.Font = new Font("Segoe UI", 14);
                label.Location = new Point(100, y + (lineSpacing * i) + symbolHeight/2);


                if (symbolEnabled == true && symbols.Count > 1 && symbols[i] != null)
                {
                    PictureBox pbox = new PictureBox();
                    pbox.Size = new Size(symbolLength, symbolHeight);
                    pbox.Name = "candidate_symbol_" + i;
                    pbox.Image = symbols[i];
                    pbox.Location = new Point(400, y + (lineSpacing * i));
                    pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.panel2.Controls.Add(pbox);
                }

                Button button = new Button();
                button.Size = new Size(buttonLength, buttonHeight);
                button.Name = "vote_button_" + i;
                button.Text = "VOTE";
                button.Font = new Font("Segoe UI", 14);
                button.Location = new Point(600, y + (lineSpacing * i) + buttonHeight/2);
                button.Click += new EventHandler(voteButton_Click);

                this.panel2.Controls.Add(label);
                this.panel2.Controls.Add(button);
                voteButtons.Add(button);
            }

            if (notaEnabled == true)
            {
                Label label = new Label();
                label.Size = new Size(textLength, textHeight);
                label.Name = "candidate_label_" + i;
                label.Text = "NOTA";
                label.Font = new Font("Segoe UI", 14);
                label.Location = new Point(100, y + (lineSpacing * i) + symbolHeight / 2);

                Button button = new Button();
                button.Size = new Size(buttonLength, buttonHeight);
                button.Name = "vote_button_" + i;
                button.Text = "VOTE";
                button.Font = new Font("Segoe UI", 14);
                button.Location = new Point(600, y + (lineSpacing * i) + buttonHeight / 2);
                button.Click += new EventHandler(voteButton_Click);

                this.panel2.Controls.Add(label);
                this.panel2.Controls.Add(button);
            }
        }

        private void Security()
        {
            totalVotes++;
            label20.Text = "" + totalVotes;
            label19.Text = "Security";
            Form ss = new Security(secKey, exitKey);
            ss.ShowDialog();
            label19.Text = "Ready to Vote";
        }

        private void voteButton_Click(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            int index = Int32.Parse(button.Name.Split('_')[2]);
            votes[index] += 1;
            panel2.Focus();
            Console.Beep(500, 3000);
            Security();
            Globals.Results = new Results(votes, totalVotes, notaEnabled);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s++;
            if (h >= 1)
            {
                label16.Text = h.ToString() + " Hours " + m.ToString() + " Minutes"; 
                if (s == 60)
                {
                    m++;
                    label16.Text = m.ToString() + " Minutes";
                    s = 0;
                    if (m == 60)
                    {
                        h++;
                        m = 0;
                    }
                }
            }
            if (h < 1)
            {
                if (s == 60)
                {
                    m++;
                    label16.Text = m.ToString() + " Minutes";

                    s = 0;
                    if (m == 60)
                    {
                        h++;
                        label16.Text = h.ToString() + " Hours " + m.ToString() + " Minutes";
                        m = 0;
                    }
                }
            }
        }
    }
}
