using System;
using UnityEngine;

namespace GameComponents
{
    public class PlayerCoin : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _renderer;
        
        public int Balance { get; private set; }

        public void Initialize(Sprite sprite, int balance)
        {
            if (balance < 0) throw new ArgumentOutOfRangeException("Balance amount can't be negative");

            _renderer.sprite = sprite;
            Balance = balance;
        }

        public void AddForce(Vector2 force)
        {
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
