using System;

namespace GameComponents.Achievements.Performers
{
    [Serializable]
    public class OneActionPerformer : AchievementPerformer
    {
        private bool _performed;

        public void TryPerform()
        {
            if (_performed) return;

            _performed = true;
            AddProgress();
        }
    }
}
