using UnityEngine;

namespace MenuComponents
{
    public class ShopCoinsHandler : MonoBehaviour
    {
        [SerializeField] private ShopCoin _chosenCoin;

        public void SetChosenCoin(ShopCoin coin)
        {
            if (_chosenCoin == coin) return;

            _chosenCoin?.Deselect();
            _chosenCoin = coin;
        }
    }
}