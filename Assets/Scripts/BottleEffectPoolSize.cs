using UnityEngine;

namespace EffectsSpace
{
    public class BottleEffectPoolSize : EffectPoolObject
    {
        [SerializeField] private GameObject _objectToPool;
        [SerializeField] private Transform _parentTransform;
        [SerializeField] private int _poolSize = 10;
        public static BottleEffectPoolSize Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            SetObjectPool(_objectToPool, _parentTransform);
            AddObjectToPool(_poolSize);
        }
    }
}