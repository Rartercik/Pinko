using UnityEngine;
using TMPro;

namespace GameComponents
{
    public class Balance : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _visualization;
        [SerializeField] private int _minBalance;
        [SerializeField] private int _maxBalance;
        [SerializeField] private int _delta;

        [field: SerializeField] public int Value { get; private set; }

        private void OnValidate()
        {
            if (_minBalance < 0)
            {
                _minBalance = 0;
            }
            if (_maxBalance < _minBalance)
            {
                _maxBalance = _minBalance;
            }

            if (_delta < 1)
            {
                _delta = 1;
            }

            SetCorrectBalance();
        }

        public void TryAdd()
        {
            Value += _delta;
            SetCorrectBalance();
        }

        public void TrySubtract()
        {
            Value -= _delta;
            SetCorrectBalance();
        }

        private void SetCorrectBalance()
        {
            Value = Mathf.Clamp(Value, _minBalance, _maxBalance);
            _visualization.text = Value.ToString();
        }
    }
}