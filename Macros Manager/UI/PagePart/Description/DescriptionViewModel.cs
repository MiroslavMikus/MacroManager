﻿using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xaml;
using Macros_Manager.Annotations;
using Macros_Manager.Tools;
using Macros_Manager.UI.Tools;
using Markdig;
using Markdig.Wpf;
using Newtonsoft.Json;
using XamlReader = System.Windows.Markup.XamlReader;

namespace Macros_Manager.UI.PagePart.Description
{
    public class DescriptionViewModel : BaseNotifyPropertyChanged
    {
        private static MarkdownPipeline BuildPipeline()
        {
            return new MarkdownPipelineBuilder()
                .UseSupportedExtensions()
                .Build();
        }

        public DescriptionViewModel()
        {
            RefreshTimer = CreateRefreshTimer();
            ProgressTimer = CreateProgressTimer();
            RefreshInterval = 5;
        }

    private DispatcherTimer CreateProgressTimer()
        {
            return new DispatcherTimer(TimeSpan.FromMilliseconds(100),
                DispatcherPriority.Normal,
                (a, b) =>
                {
                    RefreshProgress += 100.0 / (RefreshInterval * 10);
                }, Dispatcher.CurrentDispatcher);
        }

        private DispatcherTimer CreateRefreshTimer()
        {
            return new DispatcherTimer(TimeSpan.FromMilliseconds(1000),
                DispatcherPriority.Normal,
                (a, b) =>
                {
                    MdDescripiton = GenerateDocument(RawDescripiton);
                    StopTimers();
                }, Dispatcher.CurrentDispatcher);
        }

        private void StopTimers()
        {
            RefreshTimer?.Stop();
            ProgressTimer?.Stop();
            RefreshProgress = 0;
        }
        [JsonIgnore]
        public ICommand UpdateDocument => new RelayCommand<object>((a) =>
        {
            StopTimers();
            MdDescripiton = GenerateDocument(RawDescripiton);
        });

        private double _refreshProgress;
        public double RefreshProgress
        {
            get { return _refreshProgress; }
            set { this.MutateVerbose(ref _refreshProgress, value, RaisePropertyChanged()); }
        }

        private int _refreshInterval; // in seconds
        public int RefreshInterval
        {
            get { return _refreshInterval; }
            set { this.MutateVerbose(ref _refreshInterval, value, RaisePropertyChanged()); }
        }

        private string _rawDescription;
        public string RawDescripiton
        {
            get { return _rawDescription; }
            set
            {
                this.MutateVerbose(ref _rawDescription, value, RaisePropertyChanged());

                if (_disableAutoUpdate) return;

                StopTimers();
                RefreshTimer.Interval = TimeSpan.FromSeconds(RefreshInterval);
                RefreshTimer.Start();
                ProgressTimer.Start();
            }
        }

        private bool _disableAutoUpdate;
        public bool DisableAutoUpdate
        {
            get { return _disableAutoUpdate; }
            set { this.MutateVerbose(ref _disableAutoUpdate, value, RaisePropertyChanged()); }
        }

        private bool _disableEditing;
        public bool DisableEditing
        {
            get { return _disableEditing; }
            set { this.MutateVerbose(ref _disableEditing, value, RaisePropertyChanged()); }
        }

        [JsonIgnore]
        public DispatcherTimer RefreshTimer;
        [JsonIgnore]
        public DispatcherTimer ProgressTimer;

        private FlowDocument _mdDescripiton;

        [JsonIgnore]
        public FlowDocument MdDescripiton
        {
            get { return _mdDescripiton; }
            set { this.MutateVerbose(ref _mdDescripiton, value, RaisePropertyChanged()); }
        }

        private FlowDocument GenerateDocument(string a_document)
        {
            if (string.IsNullOrEmpty(a_document)) return null;

            var xaml = Markdig.Wpf.Markdown.ToXaml(a_document, BuildPipeline());

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xaml)))
            {
                var reader = new XamlXmlReader(stream, new MyXamlSchemaContext());

                var document = XamlReader.Load(reader) as FlowDocument;

                return document;
            }

        }
    }
}
