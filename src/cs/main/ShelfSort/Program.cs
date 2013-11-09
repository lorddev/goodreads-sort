using System;
using System.Collections.Generic;
using System.Linq;

namespace ShelfSort
{
    using System.Globalization;

    public class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                PrintList(args[0]);
            }
            else
            {
                Console.Write("Enter Goodreads user ID: ");
                string userId = Console.ReadLine();
                PrintList(userId);
            }
        }

        public static void PrintList(string userId)
        {
            var wrapper = new GoodreadsWrapper();

            Console.WriteLine("Getting currently-reading shelf...");
            IEnumerable<ShelfItem> shelf = wrapper.GetBookIds(userId, "currently-reading", 200);

            Console.WriteLine("Getting user statuses...");
            var bookList = new List<ISortableBook>();
            foreach (var item in shelf)
            {
                try
                {
                    wrapper = new GoodreadsWrapper();
                    var review = wrapper.GetMyReviewsForBook(item.Id.ToString(CultureInfo.InvariantCulture), userId);

                    if (review.UserStatuses.Any())
                    {
                        float bigPercent = float.Parse(review.UserStatuses.ElementAt(0).Percent);
                        var book = new SortableBook { Title = review.Book.Title, PercentRead = bigPercent};
                        bookList.Add(book);
                    }
                }
                catch (Exception ex)
                {
                    // To-do: Fix bugs...
                    Console.WriteLine(ex);
                }
            }

            Console.WriteLine("Sorting...");
            
            foreach (var book in bookList.OrderByDescending(t => t.PercentRead))
            {
                Console.WriteLine("{0} - {1}%", book.Title, book.PercentRead);
            }
        }
    }
}
