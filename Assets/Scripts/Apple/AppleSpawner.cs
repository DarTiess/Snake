using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class AppleSpawner: MonoBehaviour
    {
        private ObjectPoole<Apple> _pooler;
        private Transform _player;
        private float _radiusSpawn;

        public event Action EatenApple;

        public void Initialize(AppleConfig config, Transform player)
        {
            _pooler = new ObjectPoole<Apple>();
            _pooler.CreatePool(config.ApplePrefab,config.AppleCount,transform);
            _player = player;
            _radiusSpawn = config.AppleSpawnRadius;

            SpawnApples(config.AppleCount-1);
        }

        private void SpawnApples(int count)
        {
            for (int i = 0; i < count; i++)
            {
               Apple apple= _pooler.GetObject();
               apple.EatApple += OnEatenApple;
               apple.transform.position = _player.position + new Vector3(Random.Range(-_radiusSpawn, _radiusSpawn), _player.position.y, Random.Range(-_radiusSpawn, _radiusSpawn));

            }
        }

        private void OnEatenApple(Apple apple)
        {
            apple.EatApple -= OnEatenApple;
            EatenApple?.Invoke();
            SpawnApples(1);
        }
    }
}