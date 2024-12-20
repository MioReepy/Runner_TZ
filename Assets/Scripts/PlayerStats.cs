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
        public int minMoneyCount;
        public int maxMoneyCount;
    }

    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private int _commonMoney;
        public float CurrentMoney{get; private set;}
        public float MaxMoney {get; set;}
        
        public event Action<float> OnChangeMoney;
        public event Action OnGameOver;
        
        public static PlayerStats Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            CurrentMoney = _commonMoney;
        }

        public void SetMoney(int money)
        {
            if (CurrentMoney <= 1)
            {
                OnGameOver?.Invoke();
            }
            
            CurrentMoney += money;
            OnChangeMoney?.Invoke(CurrentMoney);
        }
    }
}