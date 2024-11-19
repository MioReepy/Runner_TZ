using PlayerSpace;
using UnityEngine;
using UnityEngine.UI;

namespace UISpace
{
    public class ProgressBarPlayer : MonoBehaviour
    {
        [SerializeField] private Player _player;
        
        [SerializeField] private Image _timer;
        private float _maxMoney;
        
        private void OnEnable()
        {
            _maxMoney = _player.PlayerStats.MaxMoney;
            _timer.fillAmount = _player.PlayerStats.CurrentMoney / _maxMoney;

            _player.PlayerStats.OnChangeMoney += OnChangeMoney;
        }
        
        private void OnDisable()
        {
            _player.PlayerStats.OnChangeMoney -= OnChangeMoney;
        }

        private void OnChangeMoney(float money)
        {
            _timer.fillAmount = money / _maxMoney;
        }
    }
}