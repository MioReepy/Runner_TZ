using SplineNameSpace;
using UnityEngine;

namespace PlayerSpace
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private SplineController _controller;
        [SerializeField] private PlayerAnimator _animator;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerStats _playerStats;

        public PlayerStats PlayerStats => _playerStats;

        private void OnEnable()
        {
            _playerStats.OnGameOver += OnGameOver;
        }

        private void OnDisable()
        {
            _playerStats.OnGameOver -= OnGameOver;
        }

        public void Win()
        {
            _playerMovement.IsCanMove = false;
            _controller.Win();
            _animator.PlayWin();
        }

        private void OnGameOver()
        {
            _animator.PlayGameOver();
            _controller.GameOver();
        }
    }
}