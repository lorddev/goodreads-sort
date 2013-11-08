using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelfSortTests
{
    using NUnit.Framework;

    [TestFixture]
    public class ProgramTest
    {
        [Test]
        public void TestProgram()
        {
            ShelfSort.Program.PrintList();
            Assert.Inconclusive();
        }
    }
}
