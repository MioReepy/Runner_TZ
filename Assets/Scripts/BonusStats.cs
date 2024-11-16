using System;
using EffectsSpace;
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
            PlayerStats.Instance.SetMoney(_bonus.count);
            GameObject effect = _bonus.bonusType == BonusType.Bill ? BillEffectPoolSize.Instance.GetPoolObject() : BottleEffectPoolSize.Instance.GetPoolObject();
            effect.SetActive(true);
            Destroy(gameObject);
        }
    }
}