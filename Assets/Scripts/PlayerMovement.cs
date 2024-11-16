using UnityEngine;

namespace PlayerSpace
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] [Range(2f, 15f)] private float _playerSpeed;
        private Vector3 _moveInput;

        public Vector2 MoveInput
        {
            set => _moveInput.x = value.x;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            Vector3 movePosition = transform.localPosition + _moveInput;
            
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,movePosition, _playerSpeed * Time.fixedDeltaTime);
        }
        
        
    }
}