using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelfSortTests
{
    using NUnit.Framework;

    using ShelfSort;

    [TestFixture]
    public class ApiWrapper
    {
        [Test]
        public void TestBookList()
        {
            var wrapper = new GoodreadsWrapper();
            var result = wrapper.GetBookIds("15469076", "currently-reading", 2);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetReadPercent()
        {
            // https://www.goodreads.com/user_status/show/34980137?format=xml&key=iBGqAvHjYE9W1CrqyreXRA
            //   &user_id=15469076-aaron-lord

            var wrapper = new GoodreadsWrapper();
            UserStatus result = null;
            Assert.DoesNotThrow(() => result = wrapper.GetUserStatusByBook(bookId: "34980137", userId: "15469076"));

            //Assert.AreEqual(.74F, result.GetPercentRead());
        }

        [Test]
        public void GetBookByIsbn()
        {
            var wrapper = new GoodreadsWrapper();
            Book book = wrapper.GetBookByIsbn("9780812992946");
            Assert.AreEqual("The Future: Six Drivers of Global Change", book.Title);

            Assert.That(book.Id.Length > 0);
        }

        [Test]
        public void GetMyReviewsForBookTest()
        {
            var wrapper = new GoodreadsWrapper();
            Review review = wrapper.GetMyReviewsForBook("526568539", "15469076");

            Assert.AreEqual(9, review.UserStatuses.Count);
            Assert.AreEqual(29, review.UserStatuses.ElementAt(0).Percent);
        }
    }
}
