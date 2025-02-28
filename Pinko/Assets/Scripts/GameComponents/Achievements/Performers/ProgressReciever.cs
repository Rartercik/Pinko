using UnityEngine;

namespace GameComponents.Achievements.Performers
{
    public class ProgressReciever : MonoBehaviour
    {
        [SerializeField] private Achievement[] _achievements;

        public void AddProgress()
        {
            foreach (var achievement in _achievements)
            {
                achievement.AddProgress();
            }
        }

        public void AddProgress(int progress)
        {
            foreach (var achievement in _achievements)
            {
                achievement.AddProgress(progress);
            }
        }
    }
}
