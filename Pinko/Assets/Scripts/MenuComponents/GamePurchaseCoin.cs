using UnityEngine;
using Data;

namespace MenuComponents
{
    public class GamePurchaseCoin : ShopCoin
    {
        [SerializeField] private MoneyHolder _moneyHolder;
        [SerializeField] private int _cost;

        protected override bool TryBuy()
        {
            return _moneyHolder.TryGetMoney(_cost);
        }

        protected override string GetCostText()
        {
            return _cost.ToString();
        }
    }
}