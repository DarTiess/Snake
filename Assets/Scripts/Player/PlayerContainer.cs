using DefaultNamespace;
using Infrastructure.Input;
using Infrastructure.Level;
using Player;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerContainer : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerTail _playerTail;
    private ILevelEvents _levelEvents;

    public void Initialize(IInputService input, ILevelEvents levelEvents, PlayerConfig config)
    {
        _levelEvents = levelEvents;
        _levelEvents.OnPlayGame += OnPlayGame;
        _playerMovement = GetComponent<PlayerMovement>();
        _playerTail = new PlayerTail(config.TailSpeed,config.TailPrefab, config.MaxTailSize , transform);
        _playerMovement.Initialize(input, config.MoveSpeed, config.RotateSpeed);
    }

    private void OnDisable()
    {
        _levelEvents.OnPlayGame -= OnPlayGame;
    }

    private void OnPlayGame()
    {
        _playerMovement.StartMove();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IFood apple))
        {
            apple.Hide();
            _playerTail.AddTailRange();
        }
    }
}