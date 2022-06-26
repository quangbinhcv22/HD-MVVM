using System;
using UnityEngine;

namespace NCB.MVVM.Demo
{
    [Serializable]
    public class PlayerData
    {
        public string name;
        public int age;
        public Sprite avatar;
        public Guid guid;

        public PlayerData()
        {
            guid = Guid.NewGuid();
        }
    }
}