using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelfSort
{
    public interface ISortableBook : IComparable
    {
        string Title { get; set; }

        float PercentRead { get; set; }
    }
}
