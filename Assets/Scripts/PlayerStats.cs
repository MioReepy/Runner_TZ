using System;
using UnityEngine;

namespace PlayerSpace
{
    public enum PlayerType
    {
        Poor = 0,
        Casual = 1,
        Middle = 2
    }
    
    [Serializable]
    public struct Player
    {
        public PlayerType playerType;
        public GameObject playerObject;
        public int count;
    }

    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private int _maxMoney;
        [SerializeField] private int _commonMoney;
        [SerializeField] private Player[] _player;
        public float CurrentMoney{get; private set;}
        
        public event Action<float> OnChangeMoney;
        
        public static PlayerStats Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            CurrentMoney = _commonMoney;
        }

        public void SetMoney(int money)
        {
            CurrentMoney += money;
            OnChangeMoney?.Invoke(CurrentMoney);
        }
    }
}