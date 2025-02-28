using UnityEngine;
using Tools;

namespace GameComponents
{
    public class ArenaChanger : MonoBehaviour
    {
        [SerializeField] private Arena[] _arenas;

        private int _arenaIndex;

        public void TurnOn(int arenaIndex, int riskIndex, bool spawningOverTime)
        {
            gameObject.SetActive(true);
            ChooseArena(arenaIndex, spawningOverTime);
            ChooseRisk(riskIndex);
        }

        public void TurnOff()
        {
            gameObject.SetActive(false);
            StopCoinSpawnOverTime();
        }

        public void TrySpawnCoin()
        {
            _arenas[_arenaIndex].TrySpawnCoin();
        }

        public void StartCoinSpawnOverTime()
        {
            _arenas[_arenaIndex].StartCoinSpawnOverTime();
        }

        public void StopCoinSpawnOverTime()
        {
            _arenas[_arenaIndex].StopCoinSpawnOverTime();
        }

        public int ChooseArena(int index, int correctRiskIndex, bool spawningOverTime)
        {
            _arenaIndex = ChooseArena(index, spawningOverTime);
            ChooseRisk(correctRiskIndex);
            return _arenaIndex;
        }

        public int ChooseRisk(int index)
        {
            return _arenas[_arenaIndex].ChooseRisk(index);
        }

        private int ChooseArena(int index, bool spawningOverTime)
        {
            _arenas[_arenaIndex].StopCoinSpawnOverTime();
            _arenaIndex = ObjectTools.TryChooseObject(_arenaIndex, index, _arenas, true);
            if (spawningOverTime)
            {
                _arenas[_arenaIndex].StartCoinSpawnOverTime();
            }
            return _arenaIndex;
        }
    }
}