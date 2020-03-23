using UnityEngine;

namespace SnakesAndLadders
{
    public class PauseUnityTimeScale : IPause
    {
        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void UnPause()
        {
            Time.timeScale = 1;
        }
    }
}