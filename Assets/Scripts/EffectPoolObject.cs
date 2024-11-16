using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EffectsSpace
{
    public abstract class EffectPoolObject : MonoBehaviour
    {
        private GameObject _objectToPoolBase;
        private Transform _parentTransformBase;
        private List<GameObject> _poolObjectsBase;

        protected void SetObjectPool(GameObject objectToPool, Transform parentTransform)
        {
            _objectToPoolBase = objectToPool;
            _parentTransformBase = parentTransform;
            _poolObjectsBase = new List<GameObject>();
        }

        internal void AddObjectToPool(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject poolTemp = Instantiate(_objectToPoolBase, transform.position, transform.rotation, _parentTransformBase);
                poolTemp.SetActive(false);
                _poolObjectsBase.Add(poolTemp);
            }
        }

        internal GameObject GetPoolObject()
        {
            foreach (var enemyObject in _poolObjectsBase.Where(enemyObject => !enemyObject.activeInHierarchy))
            {
                return enemyObject;
            }

            GameObject poolTemp = Instantiate(_objectToPoolBase, transform.position, transform.rotation, _parentTransformBase);
            poolTemp.SetActive(false);
            _poolObjectsBase.Add(poolTemp);

            return poolTemp;
        }
    }
}