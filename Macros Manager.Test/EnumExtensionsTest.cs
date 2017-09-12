using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Macros_Manager.Tools;
using Macros_Manager.Unity.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Macros_Manager.Test
{
    [TestClass]
    public class EnumExtensionsTest
    {
        [TestMethod]
        public void TestEnumToList()
        {
            // arrange
            List<string> expected = new List<string>()
            {
                NodeType.Label.ToString(),
                NodeType.Macro.ToString(),
                NodeType.Sequence.ToString(),
                NodeType.Dashboard.ToString(),
                NodeType.Data.ToString(),
            };

            // act
            var result = EnumExtensions.EnumToList(typeof(NodeType));

            // assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
