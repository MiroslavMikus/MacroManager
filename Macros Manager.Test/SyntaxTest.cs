using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Macros_Manager.Test
{
    [TestClass]
    public class SyntaxTest
    {
        [TestMethod]
        public void EnumCast()
        {
            Console.WriteLine(Types.Macro.ToString());
        }

        enum Types
        {
            Macro,
            Loop,
            Toogle
        }

        [TestMethod]
        public void AddNullToList()
        {
            var list = new List<string>();
            list.Add(null);
            list.Add(null);
            list.Add(null);
            list.Add(null);
            list.Add(null);
        }
    }
}
