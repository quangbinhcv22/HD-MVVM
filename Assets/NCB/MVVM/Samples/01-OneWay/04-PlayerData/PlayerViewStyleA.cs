using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NCB.MVVM.Demo
{
    public class PlayerViewStyleA : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private Image avatar;

        public void UpdateView(PlayerData data)
        {
            nameText.SetText(data.name);
            avatar.sprite = data.avatar;
        }
    }
}