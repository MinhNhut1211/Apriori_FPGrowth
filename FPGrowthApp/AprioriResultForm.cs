using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FPGrowthSmartApp
{
    public partial class AprioriResultForm : Form
    {
        private List<List<string>> transactions;
        private int minSup;

        public AprioriResultForm(List<List<string>> data, int support)
        {
            InitializeComponent();
            this.transactions = data;
            this.minSup = support;
            RunApriori();
        }

        private void RunApriori()
        {
            txtLog.Clear();
            int k = 1;
            // Chứa các tập phổ biến theo từng bậc: bậc 1, bậc 2...
            Dictionary<List<string>, int> currentL = GetL1();

            while (currentL.Count > 0)
            {
                DisplayL(currentL, k);
                // Sinh ứng viên C(k+1) từ L(k)
                var nextC = GenerateCandidates(currentL.Keys.ToList(), k + 1);
                // Tính toán Support và lọc để có L(k+1)
                currentL = GetNextL(nextC);
                k++;
            }
        }

        private Dictionary<List<string>, int> GetL1()
        {
            var counts = new Dictionary<string, int>();
            foreach (var trans in transactions)
            {
                foreach (var item in trans)
                {
                    if (counts.ContainsKey(item)) counts[item]++;
                    else counts[item] = 1;
                }
            }
            return counts.Where(x => x.Value >= minSup)
                         .OrderBy(x => x.Key)
                         .ToDictionary(x => new List<string> { x.Key }, x => x.Value);
        }

        private List<List<string>> GenerateCandidates(List<List<string>> prevL, int k)
        {
            List<List<string>> candidates = new List<List<string>>();
            for (int i = 0; i < prevL.Count; i++)
            {
                for (int j = i + 1; j < prevL.Count; j++)
                {
                    var l1 = prevL[i];
                    var l2 = prevL[j];
                    // Join step: Nếu k-1 phần tử đầu giống nhau
                    if (l1.Take(k - 2).SequenceEqual(l2.Take(k - 2)))
                    {
                        var candidate = l1.Union(l2).OrderBy(x => x).ToList();
                        if (candidate.Count == k) candidates.Add(candidate);
                    }
                }
            }
            return candidates;
        }

        private Dictionary<List<string>, int> GetNextL(List<List<string>> candidates)
        {
            var nextL = new Dictionary<List<string>, int>();
            foreach (var cand in candidates)
            {
                int count = transactions.Count(t => !cand.Except(t).Any());
                if (count >= minSup) nextL.Add(cand, count);
            }
            return nextL;
        }

        private void DisplayL(Dictionary<List<string>, int> L, int k)
        {
            txtLog.AppendText($"--- Tập phổ biến bậc L{k} ---\r\n");
            foreach (var item in L)
            {
                txtLog.AppendText($"{{ {string.Join(", ", item.Key)} }} : Support = {item.Value}\r\n");
            }
            txtLog.AppendText("\r\n");
        }
    }
}