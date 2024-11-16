using System;
using UnityEngine;

namespace PlayerSpace
{
    public class ChangeSkin : MonoBehaviour
    {
        [SerializeField] private Player[] _player;
        private int _currentIndexPlayer;

        public event Action<bool> OnIsPoor; 

        private void Awake()
        {
            for (int skin = 0; skin < _player.Length; skin++)
            {
                if (!_player[skin].playerObject.activeInHierarchy) continue;
                
                _currentIndexPlayer = skin;
            }
        }

        private void Start()
        {
            PlayerStats.Instance.OnChangeMoney += Instance_OnChangeMoney;
        }

        void Instance_OnChangeMoney(float money)
        {
            if (_player[_currentIndexPlayer].maxMoneyCount < money && _player.Length > _currentIndexPlayer - 1)
            {
                _player[_currentIndexPlayer].playerObject.SetActive(false);
                _currentIndexPlayer++;
                _player[_currentIndexPlayer].playerObject.SetActive(true);
            }

            if (_player[_currentIndexPlayer].minMoneyCount > money && 0 < _currentIndexPlayer)
            {
                _player[_currentIndexPlayer].playerObject.SetActive(false);
                _currentIndexPlayer--;
                _player[_currentIndexPlayer].playerObject.SetActive(true);
            }
            
            OnIsPoor?.Invoke(_currentIndexPlayer != _player.Length - 1);
        }

        private void OnDisable()
        {
            PlayerStats.Instance.OnChangeMoney -= Instance_OnChangeMoney;
        }
    }
}