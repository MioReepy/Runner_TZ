using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EffectsSpace
{
    public abstract class EffectPoolObject : MonoBehaviour
    {
        private GameObject _objectToPool;
        private Transform _parentTransform;
        private int _poolSize = 15;
        private List<GameObject> _poolObjects;

        protected void SetObjectPool(GameObject objectToPool, Transform parentTransform)
        {
            _objectToPool = objectToPool;
            _parentTransform = parentTransform;
            _poolObjects = new List<GameObject>();
        }

        internal void AddObjectToPool(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject poolTemp = Instantiate(_objectToPool, transform.position, transform.rotation, _parentTransform);
                poolTemp.SetActive(false);
                _poolObjects.Add(poolTemp);
            }
        }

        internal GameObject GetPoolObject()
        {
            foreach (var enemyObject in _poolObjects.Where(enemyObject => !enemyObject.activeInHierarchy))
            {
                return enemyObject;
            }

            GameObject poolTemp = Instantiate(_objectToPool, transform.position, transform.rotation, _parentTransform);
            poolTemp.SetActive(false);
            _poolObjects.Add(poolTemp);

            return poolTemp;
        }
    }
}