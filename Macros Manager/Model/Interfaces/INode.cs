using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Macros_Manager.UI.PagePart;
using Macros_Manager.UI.PagePart.Description;

namespace Macros_Manager.Model.Interfaces
{
    public interface INode : INotifyPropertyChanged, IHasContent
    {
        string Name { get; set; }   
        bool CanBeDeleted { get; }
        DescriptionViewModel Description { get; set; }
        void Delete(INode a_nodeToDelete);
        ICollection<INode> ChildNodes { get; set; }
    }
}