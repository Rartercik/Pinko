using UnityEngine;
using Tools;
using GameComponents.Achievements.Performers;

namespace GameComponents
{
    public class Arena : MonoBehaviour
    {
        [SerializeField] private CoinsSpawner _coinsSpawner;
        [SerializeField] private GameObject[] _bankRisks;
        [SerializeField] private OneActionPerformer _achievementPerformer;

        private int _bankIndex;

        public void TrySpawnCoin()
        {
            if (_coinsSpawner.TrySpawn() && _bankIndex == _bankRisks.Length - 1)
            {
                _achievementPerformer.TryPerform();
            }
        }

        public void StartCoinSpawnOverTime()
        {
            _coinsSpawner.StartSpawnOverTime();
        }

        public void StopCoinSpawnOverTime()
        {
            _coinsSpawner.StopSpawnOverTime();
        }

        public int ChooseRisk(int index)
        {
            _bankIndex = ObjectTools.TryChooseObject(_bankIndex, index, _bankRisks, true);
            return _bankIndex;
        }
    }
}