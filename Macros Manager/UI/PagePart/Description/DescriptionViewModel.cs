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

            MdDescripiton = new NotifyTaskCompletion<FlowDocument>(GenerateDocument(RawDescripiton));

            _updateDescription = a =>
            {
                MdDescripiton.WatchTaskAsync(GenerateDocument(a),5000);
            };

            _updateDescription.SyncWithUi(RawDescripiton);
        }

        private readonly Action<string> _updateDescription;


        public string RawDescripiton
        {
            get { return _rawDescription; }
            set
            {
                this.MutateVerbose(ref _rawDescription, value, RaisePropertyChanged());

                _updateDescription.SyncWithUi(value);
            }
        }

        public DescriptionState State { get; set; }

        private NotifyTaskCompletion<FlowDocument> _mdDescripiton;
        [JsonIgnore]
        public NotifyTaskCompletion<FlowDocument> MdDescripiton
        {
            get { return _mdDescripiton; }
            set { this.MutateVerbose(ref _mdDescripiton, value, RaisePropertyChanged()); }
        }

        private async Task<FlowDocument> GenerateDocument(string a_document)
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
