using System;
using PlayerSpace;
using UnityEngine;

namespace GameControllerSpace
{
    public class Finish : MonoBehaviour
    {
        private PlayerMovement _currentPlayerMovement = null;
        public static Finish Instance { get; private set; }

        public event Action OnWin;

        private void Awake()
        {
            Instance = this;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out PlayerMovement playerMovement)) return;
            
            OnWin?.Invoke();
        }
    }
}