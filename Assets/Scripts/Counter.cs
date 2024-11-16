using PlayerSpace;
using TMPro;
using UnityEngine;

namespace UISpace
{
    public class Counter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counterText;

        private void Start()
        {
            PlayerStats.Instance.OnChangeMoney += Instance_OnChangeMoney;
            _counterText.text = PlayerStats.Instance.CurrentMoney.ToString();
        }

        void Instance_OnChangeMoney(float _money)
        {
            _counterText.text = _money.ToString();
        }

        private void OnDisable()
        {
            PlayerStats.Instance.OnChangeMoney -= Instance_OnChangeMoney;
        }
    }
}