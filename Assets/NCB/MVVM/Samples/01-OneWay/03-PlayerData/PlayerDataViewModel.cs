using Sirenix.OdinInspector;
using UnityEngine;

namespace NCB.MVVM.Demo
{
    [Binding("Demo/PlayerData")]
    public class PlayerDataViewModel : MonoBehaviour
    {
        [ShowInInspector] public PlayerData PlayerData => FakeDatabase.PlayerData;
    }

    public static class FakeDatabase
    {
        private static PlayerData _playerData;

        public static PlayerData PlayerData
        {
            get
            {
                _playerData ??= new PlayerData()
                {
                    name = "Zitga",
                    age = 7,
                    avatar = Resources.Load<Sprite>("A"),
                };
                
                return _playerData;
            }
        }
    }
}