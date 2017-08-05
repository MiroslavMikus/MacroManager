﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Macros_Manager.UI;
using Macros_Manager.UI.Content;
using Macros_Manager.UI.NodesView;
using Macros_Manager.UI.PagePart;
using Microsoft.Practices.Unity;
using DescriptionTest = Macros_Manager.UI.PagePart.Description.DescriptionTest;

namespace Macros_Manager.Unity
{
    public class ViewModelContainer
    {
        public UnityContainer Container { get; set; }

        public ViewModelContainer()
        {
            Container = new UnityContainer();

            Container.RegisterType<MainWindowViewModel>(UnityDefs.ViewModel.Main,new ContainerControlledLifetimeManager());
            Container.RegisterType<ContentControl, DescriptionTest>(UnityDefs.ViewModel.LabelViewModel, new ContainerControlledLifetimeManager()); 
            Container.RegisterType<ContentControl, PowershellView>(UnityDefs.Powershell.View, new ContainerControlledLifetimeManager());
        }

        public MainWindowViewModel Main => Container.Resolve<MainWindowViewModel>(UnityDefs.ViewModel.Main);
    }

    public static class VmcSingeltion //View Model Container Sigelton
    {
        public static ViewModelContainer VmcContainer = new ViewModelContainer();
    }
}