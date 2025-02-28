using UnityEngine;

namespace GameComponents
{
    public class CoinsDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerCoin>(out var coin))
            {
                Destroy(coin.gameObject);
            }
        }
    }
}