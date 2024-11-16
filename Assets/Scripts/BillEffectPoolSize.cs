using UnityEngine;

namespace EffectsSpace
{
    public class BillEffectPoolSize : EffectPoolObject
    {
        [SerializeField] private GameObject _objectToPool;
        [SerializeField] private Transform _parentTransform;
        [SerializeField] private int _poolSize = 10;
        public static BillEffectPoolSize Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            SetObjectPool(_objectToPool, _parentTransform);
            AddObjectToPool(_poolSize);
        }
    }
}