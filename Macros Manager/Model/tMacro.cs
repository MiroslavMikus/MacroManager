using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Macros_Manager.Model
{
    public class tMacro  
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public tTypeDescription Description { get; set; }
        public ICollection<string> ImportedSettings { get; set; }
        public string Script { get; set; }
    }
}