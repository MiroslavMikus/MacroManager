using System;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Macros_Manager.Node;

namespace Macros_Manager.Model
{
    public class MacroContext : DbContext
    {
        public MacroContext()
            : base("MacroDb")
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<BaseTreeNode> BaseNodes { get; set; }
    }
}
