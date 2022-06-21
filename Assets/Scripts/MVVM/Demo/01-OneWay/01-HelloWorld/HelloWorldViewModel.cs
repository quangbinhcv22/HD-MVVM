using MVVM.ModelView;

namespace MVVM.Demo
{
    [Binding]
    public class HelloWorldViewModel
    {
        public string HelloText => "Hello World!";
    }
}