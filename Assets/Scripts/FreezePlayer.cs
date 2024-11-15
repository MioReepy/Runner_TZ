using PlayerSpace;
using UnityEngine;

namespace EnviromentSpace
{
    public class FreezePlayer : MonoBehaviour
    {
        private PlayerMovement _currentPlayerMovement = null;
        private bool PlayerMovementCashed = false;
        
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement) && !PlayerMovementCashed)
            {
                PlayerMovementCashed = true;
                _currentPlayerMovement = playerMovement;
                _currentPlayerMovement.enabled = false;
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (PlayerMovementCashed)
            {
                PlayerMovementCashed = true;
                _currentPlayerMovement.enabled = true;
                _currentPlayerMovement = null;
            }
        }
    }
}