using System;
using UnityEngine;
using TMPro;
using Data;

namespace GameComponents.Achievements
{
    public class Achievement : MonoBehaviour
    {
        [SerializeField] private MoneyHolder _moneyHolder;
        [SerializeField] private GameObject _rewardButton;
        [SerializeField] private GameObject _unachievedButton;
        [SerializeField] private GameObject _rewardRevievedButton;
        [SerializeField] private GameObject _updateVisualization;
        [SerializeField] private TextMeshProUGUI _rewardVisualization;
        [SerializeField] private bool _achieved;
        [SerializeField] private int _requiredProgress;
        [SerializeField] private int _reward;

        private int _performedProgress;

        private void OnValidate()
        {
            if (_requiredProgress < 1)
            {
                _requiredProgress = 1;
            }

            if (_reward < 0)
            {
                _reward = 0;
            }
            _rewardVisualization.text = _reward.ToString();

            SetAchievement(_achieved);
        }

        public void AddProgress()
        {
            AddProgress(1);
        }

        public void AddProgress(int progress)
        {
            if (_achieved) return;
            if (progress < 0) throw new ArgumentOutOfRangeException("The added progress cannot be less than zero");

            _performedProgress += progress;
            if (_performedProgress >= _requiredProgress)
            {
                MarkAchieved();
            }
        }

        public void RevieveReward()
        {
            _moneyHolder.AddMoney(_reward);
            _rewardButton.SetActive(false);
            _rewardRevievedButton.SetActive(true);
        }

        private void SetAchievement(bool achieved)
        {
            if (achieved)
            {
                MarkAchieved();
            }
            else
            {
                MarkUnachieved();
            }
        }

        private void MarkAchieved()
        {
            _achieved = true;
            _rewardButton.SetActive(true);
            _unachievedButton.SetActive(false);
            _rewardRevievedButton.SetActive(false);
            _updateVisualization.SetActive(true);
        }

        private void MarkUnachieved()
        {
            _achieved = false;
            _rewardButton.SetActive(false);
            _unachievedButton.SetActive(true);
            _rewardRevievedButton.SetActive(false);
        }
    }
}
