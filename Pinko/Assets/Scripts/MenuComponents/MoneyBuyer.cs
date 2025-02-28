using UnityEngine;
using TMPro;
using Data;

namespace MenuComponents
{
    public class MoneyBuyer : MonoBehaviour
    {
        [SerializeField] private MoneyHolder _moneyHolder;
        [SerializeField] private TextMeshProUGUI _valueVisualizer;
        [SerializeField] private TextMeshProUGUI _costVisualizer;
        [SerializeField] private int _value;
        [SerializeField] private float _cost;

        private void OnValidate()
        {
            _valueVisualizer.text = GetVisualizationText(_value);
            _costVisualizer.text = GetVisualizationText(_cost) + '$';
        }

        public void TryBuy()
        {
            _moneyHolder.AddMoney(_value);
        }

        private string GetVisualizationText(int value)
        {
            return value.ToString("N0");
        }

        private string GetVisualizationText(float value)
        {
            return value.ToString();
        }
    }
}