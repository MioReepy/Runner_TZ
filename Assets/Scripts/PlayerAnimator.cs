using System;
using UnityEngine;

namespace PlayerSpace
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _playerAnimator;
        private static readonly int IsStart = Animator.StringToHash("IsStart");

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
            _playerAnimator.SetBool(IsStart, true);

        }

        private void OnDisable()
        {
            InputController.Instance.OnStart -= Instance_OnStart;
        }
    }
}
