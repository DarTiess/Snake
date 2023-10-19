using System;
using UnityEngine;


namespace Infrastructure.Level
{
    public class LevelAction : ILevelAction, ILevelEvents
    {
        public event Action OnLevelStart;
        public event Action OnLevelWin;
        public event Action OnLateWin;
        public event Action OnLevelLost;
        public event Action OnLateLost;
        public event Action OnPlayGame;
        public event Action StopGame;
        
        private float _timeWaitLose;
        private float _timeWaitWin;
        private bool _onPaused;
        public LevelAction(float timeWaitLose, float timeWaitWin)
        {
            _timeWaitLose = timeWaitLose;
            _timeWaitWin = timeWaitWin;
            LevelStart();
        }
    
        public void LevelStart()
        {
            OnLevelStart?.Invoke();
        }

        public void PauseGame()
        {
            if (!_onPaused)
            {
                StopGame?.Invoke();
                _onPaused = true;
            }
            else
            {
                PlayGame();
                _onPaused = false;
            }
        }

        public void PlayGame()
        {
            OnPlayGame?.Invoke();
        }

        public void LevelLost()
        {
            OnLevelLost?.Invoke();
            LateLost();
        }

        private void LateLost()
        {
            while (_timeWaitLose>0)
            {
                _timeWaitLose -= Time.deltaTime;
            }
            OnLateLost?.Invoke();
        }

        public void LevelWin()
        {
            OnLevelWin?.Invoke();
            LateWin();
        }

        private void LateWin()
        {
            while (_timeWaitWin>0)
            {
                _timeWaitWin -= Time.deltaTime;
            }
            OnLateWin?.Invoke();
        }

    }
}
