using System;
using System.Threading.Tasks;
using NCB.MVVM.Demo;
using Sirenix.OdinInspector;
using PlayerData = NCB.MVVM.PlayerData;

namespace NCB.DataView
{
    // [Binding]
    public class TestObservableList : ViewModelBase
    {
        [ShowInInspector] public ZObservableCollection<PlayerData> Players { get; private set; }

        public TestObservableList()
        {
            Players = new ZObservableCollection<global::NCB.MVVM.PlayerData>()
            {
                new() {Name = "Quang Binh", Password = "QB123", Id = 1911},
                new() {Name = "Dac Minh", Password = "DM456", Id = 2405},
                new("Cong Toan", "CT789", 1609),
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