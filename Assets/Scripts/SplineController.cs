using GameControllerSpace;
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
            PlayerStats.Instance.OnGameOver += Instance_GameOver;
            Finish.Instance.OnWin += Instance_OnWin;
        }

        private void Instance_OnStart()
        {
            GetComponent<SplineAnimate>().Play();
        }

        private void Instance_GameOver()
        {
            GetComponent<SplineAnimate>().Pause();
        }
        
        private void Instance_OnWin()
        {
            GetComponent<SplineAnimate>().Pause();
        }

        private void OnDisable()
        {
            InputController.Instance.OnStart -= Instance_OnStart;
            PlayerStats.Instance.OnGameOver -= Instance_GameOver;
            Finish.Instance.OnWin -= Instance_OnWin;

        }
    }
}