using UnityEngine;

namespace MenuComponents
{
    public class MenuComponent : MonoBehaviour
    {
        [SerializeField] private MenuController _controller;
        [SerializeField] private GameObject[] _objects;

        public void SwitchOn()
        {
            _controller.Switch(_objects);
        }
    }
}