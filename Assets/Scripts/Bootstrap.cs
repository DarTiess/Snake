using CamFollow;
using DefaultNamespace;
using Infrastructure.Input;
using Infrastructure.Level;
using Planet;
using UI;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
   [Header("Player Settings")]
   [SerializeField] private PlayerContainer _playerContainer;
   [SerializeField] private PlayerConfig _playerConfig;
   [Space(20)]
   [Header("Level Settings")]
   [SerializeField] private LevelLoader _levelLoader;
   [SerializeField] private float _timeToLose;
   [SerializeField] private float _timeToWin;
   [Space(20)]
   [Header("UI Settings")]
   [SerializeField] private UIControl _uiCanvas;
   [Space(20)]
   [Header("Apple Spawner")]
   [SerializeField] private AppleSpawner _appleSpawner;
   [SerializeField] private AppleConfig _appleConfig;
   [Space(20)]
   [Header("Planet Settings")]
   [SerializeField] private PlaneSpawner _planeSpawner;
   [SerializeField] private PlanePart _planePartPrefab;
   [SerializeField] private int _planeCount;

   private IInputService _input;
   private LevelAction _levelAction;
   private CamFollower _camera;

   private void Awake()
   {
      _input = InputService();
      CreateLevelActions();
      InitializeUI();
      InitializePlayer();
      InitializeCamera();
      InitializeAppleSpawner();
      InitializePlaneSpawner();
   }

   private void InitializePlaneSpawner()
   {
      _planeSpawner.Initialize(_planePartPrefab, _planeCount);
   }

   private void InitializeAppleSpawner()
   {
      _appleSpawner.Initialize(_appleConfig, _playerContainer.transform);
   }

   private void InitializeCamera()
   {
      _camera = Camera.main.GetComponent<CamFollower>();
      _camera.Initialize(_levelAction, _playerContainer.transform);
   }

   private void InitializePlayer()
   {
      _playerContainer.Initialize(_input, _levelAction, _playerConfig);
   }

   private void InitializeUI()
   {
      _uiCanvas.Initialize(_levelAction, _levelAction, _levelLoader);
   }

   private void CreateLevelActions()
   {
      _levelAction = new LevelAction(_timeToLose, _timeToWin);
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