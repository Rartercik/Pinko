using UnityEngine;
using Data;
using GameComponents.Achievements.Performers;

namespace GameComponents
{
    public class CoinsSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private CoinInfo _coinInfo;
        [SerializeField] private PlayerCoin _coinPrefab;
        [SerializeField] private MoneyHolder _moneyHolder;
        [SerializeField] private Balance _balance;
        [SerializeField] private OneActionPerformer _achievementPerformer;
        [SerializeField] private float _angleLimit;
        [SerializeField] private float _maxForce;
        [SerializeField] private float _spawnTime;

        private bool _spawning;
        private float _spawnProgress;

        private void Update()
        {
            if (_spawning == false) return;

            _spawnProgress += Time.deltaTime / _spawnTime;
            if (_spawnProgress > 1f)
            {
                TrySpawn();
                _spawnProgress = 0f;
            }
        }

        public void StartSpawnOverTime()
        {
            _spawning = true;
        }

        public void StopSpawnOverTime()
        {
            _spawning = false;
            _spawnProgress = 0f;
        }

        public bool TrySpawn()
        {
            if (_moneyHolder.TryGetMoney(_balance.Value) == false) return false;

            var halfLimit = _angleLimit / 2f;
            var angle = Quaternion.AngleAxis(Random.Range(-halfLimit, halfLimit), Vector3.forward);
            var coin = Instantiate(_coinPrefab, _transform.position, Quaternion.identity);
            coin.Initialize(_coinInfo.Sprite, _balance.Value);
            var force = angle * Vector2.down * Random.value * _maxForce;
            coin.AddForce(force);
            if (_moneyHolder.Money == 0)
            {
                _achievementPerformer.TryPerform();
            }
            return true;
        }
    }
}
