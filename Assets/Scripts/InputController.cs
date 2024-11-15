using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerSpace
{
    public class InputController : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerInput _playerInput;
        private InputAction _move;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerInput = GetComponent<PlayerInput>();
            _move = _playerInput.actions["Move"];
        }
        
        private void FixedUpdate()
        {
            Vector2 move = _move.ReadValue<Vector2>();
            _playerMovement.MoveInput = move;
        }
    }
}