using GameControllerSpace;
using UnityEngine;

namespace PlayerSpace
{
    public class PlayerAnimator : MonoBehaviour
    {
        private ChangeSkin _skinPlayer;
        private Animator _playerAnimator;
        private readonly int _isStart = Animator.StringToHash("IsStart");
        private readonly int _isPoor = Animator.StringToHash("IsPoor");
        private readonly int _upgrade = Animator.StringToHash("Upgrade");
        private readonly int _isWin = Animator.StringToHash("IsWin");
        private readonly int _isFail = Animator.StringToHash("IsFail");

        private void Awake()
        {
            _playerAnimator = GetComponent<Animator>();
            _skinPlayer = GetComponent<ChangeSkin>();
        }

        private void Start()
        {
            InputController.Instance.OnStart += Instance_OnStart;
            _skinPlayer.OnIsPoor += SkinPlayer_OnIsPoor;
            Finish.Instance.OnWin += Instance_OnWin;
            PlayerStats.Instance.OnGameOver += Instance_OnGameOver;
        }

        private void Instance_OnStart()
        {
            _playerAnimator.SetBool(_isStart, true);
        }

        private void SkinPlayer_OnIsPoor(bool value)
        {
            if (!value)
            {
                _playerAnimator.SetTrigger(_upgrade);
            }

            _playerAnimator.SetBool(_isPoor, value);
        }

        private void Instance_OnWin()
        {
            _playerAnimator.SetBool(_isWin, true);
            GetComponent<PlayerMovement>().enabled = false;
        }

        private void Instance_OnGameOver()
        {
            _playerAnimator.SetBool(_isFail, true);
            GetComponent<PlayerMovement>().enabled = false;
        }

        private void OnDisable()
        {
            InputController.Instance.OnStart -= Instance_OnStart;
            _skinPlayer.OnIsPoor -= SkinPlayer_OnIsPoor;
            Finish.Instance.OnWin -= Instance_OnWin;
            PlayerStats.Instance.OnGameOver -= Instance_OnGameOver;
        }
    }
}
