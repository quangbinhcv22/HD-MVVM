using System;
using System.Threading.Tasks;
using MVVM.Demo;
using MVVM.ModelView;
using Sirenix.OdinInspector;

namespace MVVM.ViewBuilder
{
    [Binding]
    public class TestObservableList : ViewModelBase
    {
        [ShowInInspector] public ZObservableCollection<PlayerData> Players { get; private set; }

        public TestObservableList()
        {
            Players = new ZObservableCollection<PlayerData>()
            {
                new PlayerData() {Name = "Quang Binh", Password = "QB123", Id = 1911},
                new PlayerData() {Name = "Dac Minh", Password = "DM456", Id = 2405},
                new PlayerData() {Name = "Cong Toan", Password = "CT789", Id = 1609},
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