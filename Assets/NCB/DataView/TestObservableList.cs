using System;
using System.Threading.Tasks;
using NCB.MVVM.Demo;
using NCB.MVVM;
using Sirenix.OdinInspector;
using PlayerData = NCB.MVVM.PlayerData;

namespace NCB.DataView
{
    [Binding]
    public class TestObservableList : ViewModelBase
    {
        [ShowInInspector] public ZObservableCollection<global::NCB.MVVM.PlayerData> Players { get; private set; }

        public TestObservableList()
        {
            Players = new ZObservableCollection<global::NCB.MVVM.PlayerData>()
            {
                new global::NCB.MVVM.PlayerData() {Name = "Quang Binh", Password = "QB123", Id = 1911},
                new global::NCB.MVVM.PlayerData() {Name = "Dac Minh", Password = "DM456", Id = 2405},
                new global::NCB.MVVM.PlayerData() {Name = "Cong Toan", Password = "CT789", Id = 1609},
            };

            Players.AddListener(() => NotifyPropertyChanged(nameof(Players)));
            
            
            StartCycle();
        }
        
        private async void StartCycle()
        {
            var oneSecond = TimeSpan.FromSeconds(1);

            while (true)
            {
                await Task.Delay(oneSecond);
                Players.Add(new PlayerData() {Name = DateTime.UtcNow.ToString(), Password = "QB123", Id = 1911});
            }
        }

    }
}