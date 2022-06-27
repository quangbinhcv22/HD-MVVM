using TMPro;
using UnityEngine;

namespace NCB.MVVM.Demo
{
    public class PlayerViewStyleB : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text ageText;
        [SerializeField] private TMP_Text guidText;

        public PlayerData Data
        {
            set => UpdateView(value);
        }
        
        private void UpdateView(PlayerData data)
        {
            nameText.SetText(data.name);
            ageText.SetText(data.age.ToString());
            guidText.SetText(data.guid.ToString());
        }
    }
}