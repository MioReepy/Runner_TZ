using PlayerSpace;
using UnityEngine;

namespace EnviromentSpace
{
    public class FreezePlayer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
            {
                playerMovement.IsCanMove = false;
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
            {
                playerMovement.IsCanMove = true;
            }
        }
    }
}