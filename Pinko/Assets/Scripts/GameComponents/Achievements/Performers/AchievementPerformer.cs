using UnityEngine;

namespace GameComponents.Achievements.Performers
{
    public abstract class AchievementPerformer
    {
        [SerializeField] private ProgressReciever _achievement;

        protected void AddProgress()
        {
            _achievement.AddProgress();
        }

        protected void AddProgress(int progress)
        {
            _achievement.AddProgress(progress);
        }
    }
}
