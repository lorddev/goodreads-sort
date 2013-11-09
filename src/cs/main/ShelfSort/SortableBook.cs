namespace ShelfSort
{
    public class SortableBook : ISortableBook
    {
        public int CompareTo(object obj)
        {
            var other = (ISortableBook)obj;
            
            if (PercentRead > other.PercentRead)
            {
                return 1;
            }

            if (PercentRead < other.PercentRead)
            {
                return -1;
            }

            return 0;
        }
        
        public string Title { get; set; }

        public float PercentRead { get; set; }
    }
}