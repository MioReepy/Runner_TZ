using PlayerSpace;
using UnityEngine;
using UnityEngine.Splines;

namespace SplineNameSpace
{
    public class SplineController : MonoBehaviour
    {
        private void Start()
        {
            InputController.Instance.OnStart += Instance_OnStart;
        }

        private void Instance_OnStart()
        {
            GetComponent<SplineAnimate>().Play();
        }

        private void OnDisable()
        {
            InputController.Instance.OnStart -= Instance_OnStart;
        }
    }
}