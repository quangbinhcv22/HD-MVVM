using System;
using UnityEngine;

namespace MVVM.Demo
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