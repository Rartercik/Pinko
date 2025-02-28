using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameComponents.Achievements.Performers;
using Data;

namespace MenuComponents
{
    public abstract class ShopCoin : MonoBehaviour
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Image _spriteVisualization;
        [SerializeField] private GameObject _selectedVisualization;
        [SerializeField] private GameObject _boughtVisualization;
        [SerializeField] private GameObject _costVisualizationObject;
        [SerializeField] private TextMeshProUGUI _costVisualization;
        [SerializeField] private ShopCoinsHandler _shopCoinsHandler;
        [SerializeField] private CoinInfo _coinInfo;
        [SerializeField] private OneActionPerformer _achievement;
        [SerializeField] private bool _isBought;
        [SerializeField] private bool _isChosen;

        private void OnValidate()
        {
            if (_isBought == false && _isChosen)
            {
                _isBought = true;
            }

            _spriteVisualization.sprite = _sprite;
            _costVisualization.text = GetCostText();
            if (_isBought && _isChosen)
            {
                _shopCoinsHandler.SetChosenCoin(this);
            }
            VisualizeDescription();
        }

        public void ProcessClick()
        {
            if (_isBought)
            {
                _isChosen = true;
                _shopCoinsHandler.SetChosenCoin(this);
                _coinInfo.SetSprite(_sprite);
                VisualizeDescription();
                return;
            }

            _isBought = TryBuy();
            if (_isBought)
            {
                _achievement.TryPerform();
            }
            VisualizeDescription();
        }

        public void Deselect()
        {
            _isChosen = false;
            VisualizeDescription();
        }

        protected abstract bool TryBuy();

        protected abstract string GetCostText();

        private void VisualizeDescription()
        {
            var chosen = _isChosen;
            var bought = _isBought && _isChosen == false;
            var cost = chosen == false && bought == false;

            _selectedVisualization.SetActive(chosen);
            _boughtVisualization.SetActive(bought);
            _costVisualizationObject.SetActive(cost);
        }
    }
}
