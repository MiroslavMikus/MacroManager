using System.Collections.Generic;

namespace Macros_Manager.Model
{
    public class MacroData  
    {
        public string Name { get; set; }

        public TypeDescriptionData Description { get; set; }
        public ICollection<string> ImportedSettings { get; set; }
        public string Script { get; set; }
    }
}