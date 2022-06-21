using TMPro;
using UnityEngine;

namespace MVVM.Demo
{
    public class PlayerViewStyleB : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text ageText;
        [SerializeField] private TMP_Text guidText;

        public void UpdateView(PlayerData data)
        {
            nameText.SetText(data.name);
            ageText.SetText(data.age.ToString());
            guidText.SetText(data.guid.ToString());
        }
    }
}