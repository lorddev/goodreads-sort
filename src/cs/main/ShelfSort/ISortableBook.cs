using System;

namespace ShelfSort
{
    public interface ISortableBook : IComparable
    {
        string Title { get; set; }

        float PercentRead { get; set; }
    }
}
