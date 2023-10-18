using System;
using DefaultNamespace;
using Infrastructure.Input;
using Infrastructure.Level;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerContainer : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private ILevelEvents _levelEvents;

    public void Initialize(IInputService input, ILevelEvents levelEvents, float moveSpeed, float rotateSpeed)
    {
        _levelEvents = levelEvents;
        _levelEvents.OnPlayGame += OnPlayGame;
        _playerMovement = GetComponent<PlayerMovement>();
        _playerMovement.Initialize(input, moveSpeed, rotateSpeed);
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
        if (collision.gameObject.TryGetComponent(out Apple apple))
        {
            apple.Hide();
        }
    }
}