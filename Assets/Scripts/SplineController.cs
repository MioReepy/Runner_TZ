using PlayerSpace;
using UnityEngine;
using UnityEngine.Splines;

namespace SplineNameSpace
{
    public class SplineController : MonoBehaviour
    {
        private SplineAnimate _splineAnimate;

        private void Awake()
        {
            _splineAnimate = GetComponent<SplineAnimate>();
        }

        private void OnEnable()
        {
            InputController.Instance.OnStart += OnStartController;
        }
        
        private void OnDisable()
        {
            InputController.Instance.OnStart -= OnStartController;
        }

        private void OnStartController()
        {
            _splineAnimate.Play();
        }

        public void GameOver()
        {
            _splineAnimate.Pause();
        }
        
        public void Win()
        {
            _splineAnimate.Pause();
        }
    }
}