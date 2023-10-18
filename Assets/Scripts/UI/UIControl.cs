using Infrastructure.Level;
using UI.UIPanels;
using UnityEngine;

namespace UI
{
    public class UIControl : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private StartMenu _panelMenu;
        [SerializeField] private GamePanel _panelInGame;
        [SerializeField] private WinPanel _panelWin;  
        [SerializeField] private LostPanel _panelLost;

        private ILevelAction _levelAction;
        private ILevelEvents _levelEvents;
        private ILevelLoader _levelLoader;
        public void Initialize(ILevelAction levAction, ILevelEvents levelEvents, ILevelLoader levelLoader)
        {
            _levelAction = levAction;
            _levelEvents = levelEvents;
            _levelLoader = levelLoader;
     
            _levelEvents.OnLevelStart += OnLevelStart;
            _levelEvents.OnLateWin += OnLevelWin; 
            _levelEvents.OnLateLost += OnLevelLost;

            _panelMenu.ClickedPanel += OnPlayGame;
            _panelLost.ClickedPanel += RestartGame;
            _panelInGame.ClickedPanel += OnPauseGame;
            _panelWin.ClickedPanel += LoadNextLevel;
            OnLevelStart();
        }

        private void OnDisable()
        {
            _levelEvents.OnLevelStart -= OnLevelStart;
            _levelEvents.OnLateWin -= OnLevelWin; 
            _levelEvents.OnLateLost -= OnLevelLost;

            _panelMenu.ClickedPanel -= OnPlayGame;
            _panelLost.ClickedPanel -= RestartGame;
            _panelInGame.ClickedPanel -= OnPauseGame;
            _panelWin.ClickedPanel -= LoadNextLevel;
        }

        private void OnLevelStart()      
        {   
            HideAllPanels();
            _panelMenu.Show();
        }
                             
        private void OnLevelWin()      
        {    
            Debug.Log("Level Win"); 
            HideAllPanels();
            _panelWin.Show();  
        }

        private void OnLevelLost()           
        {                                                     
            Debug.Log("Level Lost");  
            HideAllPanels();
            _panelLost.Show();
        }
        private void OnPauseGame()
        {
            _levelAction.PauseGame();
        }

        private void OnPlayGame()
        { 
            _levelAction.PlayGame();
            HideAllPanels(); 
            _panelInGame.Show();         
        }
        private void LoadNextLevel()
        {
            _levelLoader.LoadNextLevel();
        }

        private void RestartGame()
        {
            _levelLoader.RestartScene();
        }

        private void HideAllPanels()
        {
            _panelMenu.Hide();
            _panelLost.Hide();
            _panelWin.Hide();
            _panelInGame.Hide();
        }
    
    }
}
