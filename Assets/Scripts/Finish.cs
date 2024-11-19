using PlayerSpace;
using UnityEngine;

namespace GameControllerSpace
{
    public class Finish : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Player player))
            {
                return;
            }
            
            player.Win();
        }
    }
}