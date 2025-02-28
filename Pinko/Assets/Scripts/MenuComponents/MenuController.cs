using UnityEngine;

namespace MenuComponents
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private GameObject[] _defaultObjects;

        private GameObject[] _usingObjects;

        private void Start ()
        {
            _usingObjects = _defaultObjects;
        }

        public void SwitchToDefault()
        {
            Switch(_defaultObjects);
        }

        public void Switch(GameObject[] usingObjects)
        {
            foreach (var item in _usingObjects)
            {
                item.SetActive(false);
            }

            foreach (var item in usingObjects)
            {
                item.SetActive(true);
            }
            _usingObjects = usingObjects;
        }
    }
}
