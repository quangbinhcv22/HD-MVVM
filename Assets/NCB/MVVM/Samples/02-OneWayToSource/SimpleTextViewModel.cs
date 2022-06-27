namespace NCB.MVVM.Demo
{
    [Binding("Demo/SimpleText")]
    public class SimpleTextViewModel : ViewModelBase
    {
        private string _content;

        public string Content
        {
            get => _content;
            set => SetProperty(nameof(Content) ,ref _content, value);
        }

        public SimpleTextViewModel()
        {
            Content = "Hello world!";
        }
    }
}