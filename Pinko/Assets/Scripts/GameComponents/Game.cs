using UnityEngine;
using Tools;

namespace GameComponents
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Canvas _mainWindow;
        [SerializeField] private Canvas _gameWindow;
        [SerializeField] private GameObject _gameObjectsParent;
        [SerializeField] private ArenaChanger[] _arenaTypes;
        private int _arenaTypeIndex;
        private int _arenaIndex;
        private int _riskIndex;
        private bool _spawningOverTime;

        public void StartGame()
        {
            _mainWindow.enabled = false;
            _gameWindow.enabled = true;
            _gameObjectsParent.SetActive(true);
            _arenaTypes[_arenaTypeIndex].TurnOn(_arenaIndex, _riskIndex, _spawningOverTime);
        }

        public void EndGame()
        {
            _mainWindow.enabled = true;
            _gameWindow.enabled = false;
            _gameObjectsParent.SetActive(false);
            _arenaTypes[_arenaTypeIndex].TurnOff();
            _spawningOverTime = false;
        }

        public void ChooseNextArenaType()
        {
            _arenaTypeIndex = ObjectTools.TryChooseObject(_arenaTypeIndex, _arenaTypeIndex + 1, _arenaTypes, true);
            _arenaTypes[_arenaTypeIndex].ChooseArena(_arenaIndex, _riskIndex, _spawningOverTime);
        }

        public int ChoosePreviousArena()
        {
            _arenaIndex--;
            _arenaIndex = _arenaTypes[_arenaTypeIndex].ChooseArena(_arenaIndex, _riskIndex, _spawningOverTime);
            return _arenaIndex;
        }

        public int ChooseNextArena()
        {
            _arenaIndex++;
            _arenaIndex = _arenaTypes[_arenaTypeIndex].ChooseArena(_arenaIndex, _riskIndex, _spawningOverTime);
            return _arenaIndex;
        }

        public int ChoosePreviousRisk()
        {
            _riskIndex--;
            _riskIndex = _arenaTypes[_arenaTypeIndex].ChooseRisk(_riskIndex);
            return _arenaIndex;
        }

        public int ChooseNextRisk()
        {
            _riskIndex++;
            _riskIndex = _arenaTypes[_arenaTypeIndex].ChooseRisk(_riskIndex);
            return _riskIndex;
        }

        public void TrySpawnCoin()
        {
            _arenaTypes[_arenaTypeIndex].TrySpawnCoin();
        }

        public void StartCoinSpawnOverTime()
        {
            _arenaTypes[_arenaTypeIndex].StartCoinSpawnOverTime();
            _spawningOverTime = true;
        }

        public void StopCoinSpawnOverTime()
        {
            _arenaTypes[_arenaTypeIndex].StopCoinSpawnOverTime();
            _spawningOverTime = false;
        }
    }
}
