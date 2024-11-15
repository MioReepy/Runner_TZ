using PlayerSpace;
using UnityEngine;

namespace EnviromentSpace
{
    public class FreezePlayer : MonoBehaviour
    {
        private PlayerMovement _currentPlayerMovement = null;
        private bool _playerMovementCashed = false;
        
        private void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out PlayerMovement playerMovement) || _playerMovementCashed) return;
            
            _playerMovementCashed = true;
            _currentPlayerMovement = playerMovement;
            _currentPlayerMovement.enabled = false;
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (!_playerMovementCashed) return;
            
            _playerMovementCashed = false;
            _currentPlayerMovement.enabled = true;
            _currentPlayerMovement = null;
        }
    }
}