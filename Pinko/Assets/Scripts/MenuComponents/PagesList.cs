using UnityEngine;
using Tools;

namespace MenuComponents
{
    public class PagesList : MonoBehaviour
    {
        [SerializeField] private GameObject _leftButton;
        [SerializeField] private GameObject _rightButton;
        [SerializeField] private GameObject[] _pages;

        private int _pageIndex;

        public void TryChoosePrevious()
        {
            TryChoose(_pageIndex - 1);
        }

        public void TryChooseNext()
        {
            TryChoose(_pageIndex + 1);
        }

        private void TryChoose(int index)
        {
            _pageIndex = ObjectTools.TryChooseObject(_pageIndex, index, _pages, false);
            var leftButtonActivity = _pageIndex > 0;
            var rightButtonActivity = _pageIndex < _pages.Length - 1;
            _leftButton.SetActive(leftButtonActivity);
            _rightButton.SetActive(rightButtonActivity);
        }
    }
}