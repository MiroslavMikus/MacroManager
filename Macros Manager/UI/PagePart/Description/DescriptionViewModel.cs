using System;
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

        private string _rawDescription;

        public DescriptionViewModel(DescriptionState a_initState = DescriptionState.SplitView)
        {
            State = a_initState;
            Timer = CreateTimer();
        }

        public DispatcherTimer CreateTimer()
        {
            return new DispatcherTimer(TimeSpan.FromMilliseconds(1000),
                DispatcherPriority.Normal,
                (a, b) =>
                {
                    MdDescripiton = GenerateDocument(RawDescripiton);
                    Timer?.Stop();
                }, Dispatcher.CurrentDispatcher);
        }

        [JsonIgnore]
        public ICommand UpdateDocument => new RelayCommand<object>((a) =>
        {
            MdDescripiton = GenerateDocument(RawDescripiton);
        });

        private double _dismissButtonProgress;
        public double DismissButtonProgress
        {
            get { return _dismissButtonProgress; }
            set { this.MutateVerbose(ref _dismissButtonProgress, value, RaisePropertyChanged()); }
        }


        public string RawDescripiton
        {
            get { return _rawDescription; }
            set
            {
                this.MutateVerbose(ref _rawDescription, value, RaisePropertyChanged());
                Timer.Interval = TimeSpan.FromMilliseconds(1000);
                Timer.Start();
            }
        }

        public DispatcherTimer Timer;

        public DescriptionState State { get; set; }

        public FlowDocument _mdDescripiton;

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

        [JsonIgnore]
        public ICommand ChangeView => new RelayCommand<object>(a =>
        {
            State = State.Next();
        });
    }
}
