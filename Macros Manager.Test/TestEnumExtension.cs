using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Macros_Manager.UI.PagePart;

namespace Macros_Manager.Test
{
    [TestClass]
    public class TestEnumExtension
    {
        [TestMethod]
        public void TestEnum1()
        {
            var en = DescriptionState.ViewOnly;

            var next = en.Next();

            Assert.AreEqual(next, DescriptionState.SplitView);
        }

        [TestMethod]
        public void TestEnum2()
        {
            var en = DescriptionState.SplitView;

            var next = en.Next();

            Assert.AreEqual(next, DescriptionState.EditOnly);
        }
        [TestMethod]
        public void TestEnum3()
        {
            var en = DescriptionState.EditOnly;

            var next = en.Next();

            Assert.AreEqual(next, DescriptionState.ViewOnly);
        }
    }
}
