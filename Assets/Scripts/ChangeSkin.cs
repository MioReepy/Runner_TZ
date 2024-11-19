using System;
using UnityEngine;

namespace PlayerSpace
{
    public class ChangeSkin : MonoBehaviour
    {
        [SerializeField] private PlayerStats _playerStats;
        [SerializeField] private PlayerState[] _player;
        private int _currentIndexPlayer;

        public event Action<bool> OnIsPoor; 

        private void Awake()
        {
            for (int skin = 0; skin < _player.Length; skin++)
            {
                if (!_player[skin].playerObject.activeInHierarchy) continue;
                
                _currentIndexPlayer = skin;
            }
            
            _playerStats.MaxMoney = _player[^1].maxMoneyCount;
        }

        private void OnEnable()
        {
            _playerStats.OnChangeMoney -= OnChangeMoney;
        }
        
        private void OnDisable()
        {
            _playerStats.OnChangeMoney -= OnChangeMoney;
        }

        void OnChangeMoney(float money)
        {
            if (_player[_currentIndexPlayer].maxMoneyCount < money && _player.Length  - 1 > _currentIndexPlayer)
            {
                _player[_currentIndexPlayer].playerObject.SetActive(false);
                _currentIndexPlayer++;
                _player[_currentIndexPlayer].playerObject.SetActive(true);
                OnIsPoor?.Invoke(false);
            }

            if (!(_player[_currentIndexPlayer].minMoneyCount > money) || 0 >= _currentIndexPlayer) return;
            
            _player[_currentIndexPlayer].playerObject.SetActive(false);
            _currentIndexPlayer--;
            _player[_currentIndexPlayer].playerObject.SetActive(true);
            OnIsPoor?.Invoke(true);
        }
    }
}