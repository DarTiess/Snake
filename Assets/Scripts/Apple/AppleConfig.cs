using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Apples", fileName = "AppleConfig", order = 52)]
public class AppleConfig : ScriptableObject
{
    [SerializeField] private float _appleSpawnRadius;
    [SerializeField] private Apple _applePrefab;
    [SerializeField] private int _appleCount;
   
    public float AppleSpawnRadius=>_appleSpawnRadius;
    public Apple ApplePrefab=>_applePrefab;
    public int AppleCount=>_appleCount;
}