using TMPro;
using UnityEngine;

namespace Internal.Codebase
{
    public class EconomyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text currencyText;
        [SerializeField] private TMP_Text peopleText;

        public void UpdateEconomyDisplay(int people, int currency)
        {
            currencyText.text = currency.ToString();
            peopleText.text = people.ToString();
        }
    }
}