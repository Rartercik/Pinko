using System;
using UnityEngine;
using TMPro;
using Data;
using Tools;
using GameComponents.Achievements.Performers;

namespace MenuComponents
{
    public class SpinWheel : MonoBehaviour
    {
        [SerializeField] private SpinWheelPart[] _wheelParts;
        [SerializeField] private TextMeshProUGUI _waitTimeVisualization;
        [SerializeField] private GameObject _spinButton;
        [SerializeField] private GameObject _waitButton;
        [SerializeField] private GameObject _updateVisualization;
        [SerializeField] private MoneyHolder _moneyHolder;
        [SerializeField] private OneActionPerformer _useAchievement;
        [SerializeField] private SimpleAdditionPerformer _earnAchievement;
        [SerializeField] private float _waitTimeHours;
        [SerializeField] private float _minInterval;
        [SerializeField] private float _maxInterval;
        [SerializeField] private float _spinDuration;
        [SerializeField] private float _spinEndTime;

        private int _wheelIndex;
        private double _waitSeconds;
        private float _intervalSeconds;
        private float _interval;
        private float _spinProgress;
        private float _spinEndProgress;
        private bool _spinning;

        private void Update()
        {
            UpdateWaitTime();
            UpdateInterval();
        }

        public void TrySpin()
        {
            if (_spinning || _waitSeconds > 0) return;

            _interval = UnityEngine.Random.Range(_minInterval, _maxInterval);
            _spinning = true;
            _useAchievement.TryPerform();
        }

        private void StopSpin()
        {
            _wheelParts[_wheelIndex].gameObject.SetActive(false);
            var winAmount = _wheelParts[_wheelIndex].WinAmount;
            _moneyHolder.AddMoney(winAmount);
            _earnAchievement.AddProgress(winAmount);
            _wheelIndex = 0;
            _spinning = false;
            _spinProgress = 0f;
            _spinEndProgress = 0f;
            _waitSeconds = _waitTimeHours * 60 * 60;
            _spinButton.SetActive(false);
            _waitButton.SetActive(true);
        }

        private void UpdateWaitTime()
        {
            if (_spinning == false)
            {
                _waitSeconds -= Time.deltaTime;
                if (_waitSeconds <= 0f)
                {
                    _waitSeconds = 0f;
                    _spinButton.SetActive(true);
                    _waitButton.SetActive(false);
                    _updateVisualization.SetActive(true);
                }
                var time = TimeSpan.FromSeconds(_waitSeconds);
                _waitTimeVisualization.text = time.ToString(@"hh\:mm\:ss");
                return;
            }
        }

        private void UpdateInterval()
        {
            if (_spinning == false) return;

            _intervalSeconds += Time.deltaTime;
            _spinProgress += Time.deltaTime / _spinDuration;
            if (_spinProgress >= 1f)
            {
                _spinEndProgress += Time.deltaTime / _spinEndTime;
                if (_spinEndProgress >= 1f)
                {
                    StopSpin();
                }
            }
            else if (_intervalSeconds > _interval)
            {
                _wheelIndex = ObjectTools.TryChooseObject(_wheelIndex, _wheelIndex + 1, _wheelParts, true);
                _intervalSeconds = 0;
            }
        }
    }
}