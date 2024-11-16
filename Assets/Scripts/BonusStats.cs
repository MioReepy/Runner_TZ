using System;
using PlayerSpace;
using UnityEngine;

namespace BonusSpace
{
    public enum BonusType
    {
        Bill = 0,
        Bottle = 1,
    }

    [Serializable]
    public struct Bonus
    {
        public BonusType bonusType;
        public int count;
    }

    public class BonusStats : MonoBehaviour
    {
        [SerializeField] private Bonus _bonus;

        private void OnTriggerEnter(Collider other)
        {
            PlayerStats.Instance.CurrentMoney += _bonus.count;
        }
    }
}