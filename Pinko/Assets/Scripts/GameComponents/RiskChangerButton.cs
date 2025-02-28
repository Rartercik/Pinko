using UnityEngine;
using TMPro;

namespace GameComponents
{
    public class RiskChangerButton : MonoBehaviour
    {
        [SerializeField] private Game _game;
        [SerializeField] private TextMeshProUGUI _visualization;
        [SerializeField] private string[] _names;

        public void ChoosePrevious()
        {
            var index = _game.ChoosePreviousRisk();
            _visualization.text = _names[index];
        }

        public void ChooseNext()
        {
            var index = _game.ChooseNextRisk();
            _visualization.text = _names[index];
        }
    }
}