using UnityEngine;

namespace PlayerSpace
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _playerAnimator;
        private readonly int _isStart = Animator.StringToHash("IsStart");

        private void Awake()
        {
            _playerAnimator = GetComponent<Animator>();
        }

        private void Start()
        {
            InputController.Instance.OnStart += Instance_OnStart;
        }

        private void Instance_OnStart()
        {
            _playerAnimator.SetBool(_isStart, true);
        }

        private void OnDisable()
        {
            InputController.Instance.OnStart -= Instance_OnStart;
        }
    }
}
