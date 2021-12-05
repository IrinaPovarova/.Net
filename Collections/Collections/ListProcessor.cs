using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collections
{
    public class ListProcessor
    {
        public ListProcessor(List<int> list)
        {
        }
        public static T DeleteEvenNumbersOfPeople<T>(IEnumerable<T> source)
        {
            List<T> src = source.ToList();
            List<T> tgt = new List<T>(src.Count / 2);
            bool isDeleted = false;
            while (src.Count > 1)
            {
                foreach (T item in src)
                {
                    if (!isDeleted)
                    {
                        tgt.Add(item);
                    }
                    isDeleted = !isDeleted;
                }
                src = tgt.GetRange(0, tgt.Count);
                tgt.Clear();
            }
            return src.FirstOrDefault();
        }
    }
}
