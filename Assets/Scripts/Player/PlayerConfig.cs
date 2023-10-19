using Player;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Player", fileName = "PlayerConfig", order = 52)]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _tailSpeed;
    [SerializeField] private Tail _tailPrefab;
    [SerializeField] private int _maxTailSize;
    
    public float MoveSpeed=>_moveSpeed;
    public float RotateSpeed=>_rotateSpeed;
    public float TailSpeed=>_tailSpeed;
    public Tail TailPrefab=>_tailPrefab;
    public int MaxTailSize=>_maxTailSize;
}