using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace DigiVote
{
    public class Elections
    {

        private static String title;
        private static Int64 count;
        private static List<String> candidate = new List<String>();
        private static List<Image> symbol = new List<Image>();

        public Elections(String electionTitle, Int64 candidate_count, List<String> candidateNames, List<Image> symbols)
        {
            count = candidate_count;
            title = electionTitle;
            candidate = candidateNames;
            symbol = symbols;
        }
        public Int64 getCount()
        {
            return count;
        }
        public String getTitle()
        {
            return title;
        }
        public List<String> getCandidates()
        {
            return candidate;
        }
        public List<Image> getSymbols()
        {
            return symbol;
        }
    }

    public class Results
    {
        private List<double> votesList;
        private Int64 totalVotes;
        private bool notaEnabled;

        public Results(List<double> votes, Int64 total, bool nota)
        {
            votesList = votes;
            totalVotes = total;
            notaEnabled = nota;
        }

        public List<double> getVotes()
        {
            return votesList;
        }
        public Int64 getTotalVotes()
        {
            return totalVotes;
        }
        public bool isNotaEnabled()
        {
            return notaEnabled;
        }

    }

    public static class Globals
    {
        private static Elections _election;
        private static Results _results;
        public static Elections Election
        {
            get
            {
                return _election;
            }
            set
            {
                _election = value;
            }
        }
        public static Results Results
        {
            get
            {
                return _results;
            }
            set
            {
                _results = value;
            }
        }
    }
}
