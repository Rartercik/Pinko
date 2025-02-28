using UnityEngine;
using TMPro;
using Data;
using GameComponents.Achievements.Performers;

namespace GameComponents
{
    public class Bank : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _visualizer;
        [SerializeField] private MoneyHolder _moneyHolder;
        [SerializeField] private SimpleAdditionPerformer _additionPerformer;
        [SerializeField] private float _multiplier;

        private void OnValidate()
        {
            _visualizer.text = _multiplier.ToString();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerCoin>(out var coin))
            {
                var money = Mathf.RoundToInt(_multiplier * coin.Balance);
                _moneyHolder.AddMoney(money);
                _additionPerformer.AddProgress(money);
                Destroy(coin.gameObject);
            }
        }
    }
}