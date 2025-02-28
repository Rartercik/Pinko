using UnityEngine;
using GameComponents.Achievements.Performers;

namespace GameComponents
{
    public class PlayTimeCounter : MonoBehaviour
    {
        [SerializeField] private SimpleAdditionPerformer _additionPerformer;

        private float _time;

        private void Update()
        {
            _time += Time.deltaTime;

            if (_time > 60f)
            {
                _additionPerformer.AddProgress();
                _time = 0;
            }
        }
    }
}
