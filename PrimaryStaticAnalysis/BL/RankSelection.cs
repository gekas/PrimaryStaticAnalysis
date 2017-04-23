using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimaryStaticAnalysis.BL
{
    public class RankSelection
    {
        private int nextSelectionNumber = 1;

        public List<SelectionItem> Selection = new List<SelectionItem>();
        public List<Rank> Ranks = new List<Rank>();
        public List<double> data = new List<double>();
        public List<double> ranks = new List<double>();
        public int Count => Selection.Count;

        public bool IsReadOnly => false;

        public int AddSelection(List<double> data)
        {
            this.data.AddRange(data);

            var newSelection = data.Select(x => new SelectionItem { value = x, selection = nextSelectionNumber });
            Selection.AddRange(newSelection);

            Selection.Sort((x, y) => x.value.CompareTo(y.value));
            SetRanks();

            RefreshRanksCollection();

            ranks.Clear();
            for (int i = 0; i < data.Count; i++) ranks.Add(Selection.Where(s=>s.value==data[i]).First().rank);
            return nextSelectionNumber++;
        }

        private void SetRanks()
        {
            for (int i = 0; i < Selection.Count;)
            {
                var currentIndexCursor = i;
                List<int> similarItemsNumbers = new List<int>() { currentIndexCursor + 1 };

                while (currentIndexCursor != Selection.Count - 1
                      && Selection[currentIndexCursor].value == Selection[currentIndexCursor + 1].value)
                {
                    currentIndexCursor++;
                    similarItemsNumbers.Add(currentIndexCursor + 1);
                }


                double avg = similarItemsNumbers.Average();
                for (int j = i; j <= currentIndexCursor; j++) Selection[j].rank = avg;

                i = ++currentIndexCursor;
            }
        }

        private void RefreshRanksCollection()
        {
            Ranks.Clear();
            var ranksNumbers = Selection.Select(i => i.rank).Distinct().ToList();

            for (int i = 0; i < ranksNumbers.Count(); i++)
            {
                Ranks.Add(new Rank { rank = ranksNumbers[i], Items = Selection.Where(s => s.rank == ranksNumbers[i]).ToList() });
            }
        }
    }

    public class Rank
    {
        public List<SelectionItem> Items = new List<SelectionItem>();
        public int Count => Items.Count;
        public double rank;

        public override string ToString()
        {
            return rank.ToString();
        }
    }

    public class SelectionItem : IComparable
    {
        public double rank { get; set; }
        public int selection { get; set; }
        public double value { get; set; }

        public int CompareTo(object obj)
        {
            var newDataItem = (double)obj;
            if (newDataItem >= value) return 1;
            else if (newDataItem < value) return -1;

            return 0;
        }
    }
}
