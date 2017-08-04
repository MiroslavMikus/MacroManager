using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Xaml;
using Macros_Manager.UI.Tools;
using Markdig;
using Markdig.Wpf;
using Newtonsoft.Json;
using XamlReader = System.Windows.Markup.XamlReader;

namespace Macros_Manager.UI.PagePart
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
        }


        public string RawDescripiton
        {
            get { return _rawDescription; }
            set
            {
                this.MutateVerbose(ref _rawDescription, value, RaisePropertyChanged());

                MdDescripiton = UpdateDocument(value);
            }
        }

        public DescriptionState State { get; set; }

        private FlowDocument _mdDescripiton;
        [JsonIgnore]
        public FlowDocument MdDescripiton
        {
            get { return _mdDescripiton; }
            set { this.MutateVerbose(ref _mdDescripiton, value, RaisePropertyChanged()); }
        }

        private FlowDocument UpdateDocument(string a_document)
        {
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
    public enum DescriptionState
    {
        ViewOnly,
        SplitView,
        EditOnly
    }

    public static class EnumExtensions
    {
        public static T Next<T>(this T a_src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException($"Argumnent {typeof(T).FullName} is not an Enum");

            T[] arr = (T[])Enum.GetValues(a_src.GetType());

            int j = Array.IndexOf<T>(arr, a_src) + 1;

            return (arr.Length == j) ? arr[0] : arr[j];
        }
    }

    public class MyXamlSchemaContext : XamlSchemaContext
    {
        public override bool TryGetCompatibleXamlNamespace(string a_xamlNamespace, out string a_compatibleNamespace)
        {
            if (!a_xamlNamespace.Equals("clr-namespace:Markdig.Wpf"))
                return base.TryGetCompatibleXamlNamespace(a_xamlNamespace, out a_compatibleNamespace);

            a_compatibleNamespace = $"clr-namespace:Markdig.Wpf;assembly={Assembly.GetAssembly(typeof(Markdig.Wpf.Styles)).FullName}";

            return true;
        }
    }
}
