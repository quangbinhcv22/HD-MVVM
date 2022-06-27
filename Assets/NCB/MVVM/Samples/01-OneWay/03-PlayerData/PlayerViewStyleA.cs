using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NCB.MVVM.Demo
{
    public class PlayerViewStyleA : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private Image avatar;

        public PlayerData Data
        {
            set => UpdateView(value);
        }

        private void UpdateView(PlayerData data)
        {
            nameText.SetText(data.name);
            avatar.sprite = data.avatar;
        }
    }
}