using UnityEngine;

namespace Tools
{
    public static class ObjectTools
    {
        public static int TryChooseObject(int currentIndex, int targetIndex, GameObject[] objects, bool isCycling)
        {
            objects[currentIndex].SetActive(false);
            targetIndex = GetCorrectedIndex(targetIndex, objects.Length, isCycling);
            objects[targetIndex].SetActive(true);
            return targetIndex;
        }

        public static int TryChooseObject(int currentIndex, int targetIndex, MonoBehaviour[] objects, bool isCycling)
        {
            objects[currentIndex].gameObject.SetActive(false);
            targetIndex = GetCorrectedIndex(targetIndex, objects.Length, isCycling);
            objects[targetIndex].gameObject.SetActive(true);
            return targetIndex;
        }

        private static int GetCorrectedIndex(int index, int length, bool isCycling)
        {
            if (index < 0)
            {
                index = isCycling ? length - 1 : 0;
            }
            else if (index >= length)
            {
                index = isCycling ? 0 : length - 1;
            }
            return index;
        }
    }
}
