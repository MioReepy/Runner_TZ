using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerSpace
{
    public class InputController : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerInput _playerInput;
        private InputAction _move;
        private bool _isStart;
        
        public static InputController Instance { get; private set; }
        
        public event Action OnStart;

        private void Awake()
        {
            Instance = this;
            _playerMovement = GetComponent<PlayerMovement>();
            _playerInput = GetComponent<PlayerInput>();
            _move = _playerInput.actions["Move"];
        }
        
        private void FixedUpdate()
        {
            var move = _move.ReadValue<Vector2>();
            _playerMovement.MoveInput = move;

            if (_isStart || move == Vector2.zero) return;
            
            _isStart = true;
            OnStart?.Invoke();
        }
    }
}