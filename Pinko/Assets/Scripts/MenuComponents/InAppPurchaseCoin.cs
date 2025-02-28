using UnityEngine;

namespace MenuComponents
{
    public class InAppPurchaseCoin : ShopCoin
    {
        [SerializeField] private float _cost;

        protected override bool TryBuy()
        {
            return true;
        }

        protected override string GetCostText()
        {
            return _cost.ToString() + '$';
        }
    }
}