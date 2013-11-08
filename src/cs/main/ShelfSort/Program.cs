using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelfSort
{
    public class Program
    {
        static void Main(string[] args)
        {
           PrintList();
        }

        public static void PrintList()
        {
            var wrapper = new GoodreadsWrapper();
            IEnumerable<ShelfItem> shelf;

            string userId = "15469076";
            shelf = wrapper.GetBookIds(userId, "currently-reading", 200);

            var bookList = new List<ISortableBook>();
            foreach (var item in shelf)
            {
                try
                {
                    //wrapper = new GoodreadsWrapper();
                    //var gbook = wrapper.GetBookByIsbn(item.Isbn13);

                    wrapper = new GoodreadsWrapper();
                    //var status = wrapper.GetUserStatusByBook(gbook.Id, userId);

                    
                    //throw new NotImplementedException();

                    var review = wrapper.GetMyReviewsForBook(item.Id.ToString(), userId);

                    if (review.UserStatuses.Any())
                    {
                        //float bigPercent = review.UserStatuses.Max(x => x.Percent);

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
            
            foreach (var book in bookList.OrderByDescending(t => t.PercentRead))
            {
                Console.WriteLine("{0} - {1}%", book.Title, book.PercentRead);
            }
        }
    }
}
