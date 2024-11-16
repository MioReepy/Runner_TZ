using PlayerSpace;
using UnityEngine;
using UnityEngine.UI;

namespace UISpace
{
    public class ProgressBarPlayer : MonoBehaviour
    {
        [SerializeField] private Image _timer;
        private float _maxMoney;
        
        private void Start()
        {
            PlayerStats.Instance.OnChangeMoney += Instance_OnChangeMoney;
            _maxMoney = PlayerStats.Instance.MaxMoney;
            _timer.fillAmount = PlayerStats.Instance.CurrentMoney / _maxMoney;
        }
        
        void Instance_OnChangeMoney(float money)
        {
            _timer.fillAmount = money / _maxMoney;
        }

        private void OnDisable()
        {
            PlayerStats.Instance.OnChangeMoney -= Instance_OnChangeMoney;
        }
    }
}