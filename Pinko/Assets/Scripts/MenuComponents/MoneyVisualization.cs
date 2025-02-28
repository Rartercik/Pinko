using UnityEngine;
using TMPro;
using Data;

namespace MenuComponents
{
    public class MoneyVisualization : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _visualization;
        [SerializeField] private MoneyHolder _moneyHolder;

        private void OnEnable()
        {
            _moneyHolder.OnUpdated += UpdateVisualization;
            UpdateVisualization();
        }

        private void OnDisable()
        {
            _moneyHolder.OnUpdated -= UpdateVisualization;
        }

        private void UpdateVisualization()
        {
            _visualization.text = _moneyHolder.Money.ToString();
        }
    }
}