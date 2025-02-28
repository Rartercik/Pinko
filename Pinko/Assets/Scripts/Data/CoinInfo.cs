using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/Coin Info")]
    public class CoinInfo : ScriptableObject
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }

        public void SetSprite(Sprite sprite)
        {
            Sprite = sprite;
        }
    }
}