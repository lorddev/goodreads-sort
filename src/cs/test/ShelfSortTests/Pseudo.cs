using System;
using NUnit.Framework;

namespace ShelfSortTests
{
    using Moq;

    using ShelfSort;

    [TestFixture]
    public class Pseudo
    {
        //flaming-octo-batman
        //===================
        
        //### Pseudocode

        //1) Make call:

        //    https://www.goodreads.com/review/list/15469076?format=json&key=iBGqAvHjYE9W1CrqyreXRA&v=2&shelf=currently-reading&per_page=200

        //2) Iterate through and make calls for each book Id, e.g. 748010267

        //    https://www.goodreads.com/user_status/show/34980137?format=xml&key=iBGqAvHjYE9W1CrqyreXRA&user_id=15469076-aaron-lord

        //3) Response contains node with percent completion in prose, e.g.

        //     <header>\n\t
        //      <![CDATA[
        //        Aaron Lord is 74% done with <a href="http://www.goodreads.com/review/show/748010267">A Clash of Kings</a>
        //      ]]>
        //    </header>

        //4) Parse title and percent. If pages, calculate percent.  
        //5) Sort and output list. 

        [Test]
        public void SetupTest()
        {
            var mock = new Mock<ISortableBook>();
            mock.SetupGet(b => b.Title).Returns("Game of Thrones");
            mock.SetupGet(b => b.PercentRead).Returns(.23F);

            string expected = "Game of Thrones";
            Assert.AreEqual(expected, mock.Object.Title);
        }
    }
}
