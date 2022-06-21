using System;
using MVVM.ModelView;

namespace MVVM.Demo
{
    [Binding]
    public class UtcViewModel
    {
        public DateTime UtcTime => DateTime.UtcNow;
    }
}
