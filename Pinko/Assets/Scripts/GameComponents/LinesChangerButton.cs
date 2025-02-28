using UnityEngine;
using TMPro;

namespace GameComponents
{
    public class LinesChangerButton : MonoBehaviour
    {
        [SerializeField] private Game _game;
        [SerializeField] TextMeshProUGUI _visualization;
        [SerializeField] private string[] _names;

        public void ChoosePrevious()
        {
            var index = _game.ChoosePreviousArena();
            _visualization.text = _names[index];
        }

        public void ChooseNext()
        {
            var index = _game.ChooseNextArena();
            _visualization.text = _names[index];
        }
    }
}