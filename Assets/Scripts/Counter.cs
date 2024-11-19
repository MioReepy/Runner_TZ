using PlayerSpace;
using TMPro;
using UnityEngine;

namespace UISpace
{
    public class Counter : MonoBehaviour
    {
        [SerializeField] private Player _player;
        
        [SerializeField] private TextMeshProUGUI _counterText;

        private void OnEnable()
        {
            _player.PlayerStats.OnChangeMoney += Instance_OnChangeMoney;
            
            _counterText.text = _player.PlayerStats.CurrentMoney.ToString();
        }
        
        private void OnDisable()
        {
            _player.PlayerStats.OnChangeMoney -= Instance_OnChangeMoney;
        }

        void Instance_OnChangeMoney(float _money)
        {
            _counterText.text = _money.ToString();
        }
    }
}