using System;

namespace NCB.MVVM
{
    public interface IEventWatcher : IDisposable
    {
        public void Watch();
    }
}