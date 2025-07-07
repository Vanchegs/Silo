using TMPro;
using UnityEngine;

namespace Internal.Codebase
{
    public class EconomyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text currencyText;
        [SerializeField] private TMP_Text peopleText;

        private void Start() => 
            EconomyService.OnUpdateEconomyDisplay += UpdateEconomyDisplay;

        private void OnDisable() => 
            EconomyService.OnUpdateEconomyDisplay -= UpdateEconomyDisplay;

        private void UpdateEconomyDisplay(int people, int currency)
        {
            currencyText.text = currency.ToString();
            peopleText.text = people.ToString();
        }
    }
}