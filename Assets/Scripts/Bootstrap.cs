using CamFollow;
using Infrastructure.Input;
using Infrastructure.Level;
using UI;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
   [Header("Player Settings")]
   [SerializeField] private PlayerContainer _playerContainer;
   [SerializeField] private float _moveSpeed;
   [SerializeField] private float _rotateSpeed;
   [Space(20)]
   [Header("Level Settings")]
   [SerializeField] private LevelLoader _levelLoader;
   [SerializeField] private float _timeToLose;
   [SerializeField] private float _timeToWin;
   [Space(20)]
   [Header("UI Settings")]
   [SerializeField] private UIControl _uiCanvas;

   private IInputService _input;
   private LevelAction _levelAction;
   private CamFollower _camera;

   private void Awake()
   {
      _input = InputService();

      _levelAction = new LevelAction(_timeToLose, _timeToWin);
      _uiCanvas.Initialize(_levelAction, _levelAction, _levelLoader);
      
      _playerContainer.Initialize(_input,_levelAction, _moveSpeed, _rotateSpeed);
      
      _camera = Camera.main.GetComponent<CamFollower>();
      _camera.Initialize(_levelAction, _playerContainer.transform);
   }


   private IInputService InputService()
   {
      if (Application.isEditor)
      {
         return new StandaloneInputService();
      }
      else
      {
         return new MobileInputService();
      }
   }
}