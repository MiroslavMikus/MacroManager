using System.ComponentModel.DataAnnotations;

namespace Macros_Manager.Model
{
    public class ControllerData
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public MacroData Macro { get; set; }
    }
}