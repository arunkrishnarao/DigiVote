using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace DigiVote
{
    public partial class Result : Form
    {
        static string path1 = Directory.GetCurrentDirectory();
        bool notaEnabled;
        List<double> votes;
        List<String> candidates;
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public Result()
        {
            InitializeComponent();
            candidates = Globals.Election.getCandidates();
            votes = Globals.Results.getVotes();
            notaEnabled = Globals.Results.isNotaEnabled();
            label18.Text = Globals.Election.getTitle();

            int i;
            for(i=0; i < Globals.Election.getCount(); i++)
            {
                dataGridView1.Rows.Add(candidates[i], votes[i]);
            }
            if (notaEnabled)
            {
                dataGridView1.Rows.Add("NOTA", votes[i]);
            }
        }
    }
}
