using System;

namespace GameComponents.Achievements.Performers
{
    [Serializable]
    public class SimpleAdditionPerformer : AchievementPerformer
    {
        public new void AddProgress()
        {
            base.AddProgress();
        }

        public new void AddProgress(int progress)
        {
            base.AddProgress(progress);
        }
    }
}
