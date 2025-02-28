using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/Money Holder")]
    public class MoneyHolder : ScriptableObject
    {
        [field: SerializeField] public int Money { get; private set; }

        public event Action OnUpdated;

        public bool TryGetMoney(int money)
        {
            if (Money < money) return false;

            Money -= money;
            OnUpdated?.Invoke();
            return true;
        }

        public void AddMoney(int money)
        {
            if (money < 0) throw new ArgumentOutOfRangeException("Money amount can't be negative");

            Money += money;
            OnUpdated?.Invoke();
        }
    }
}