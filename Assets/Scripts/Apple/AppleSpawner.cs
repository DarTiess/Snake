using UnityEngine;

namespace DefaultNamespace
{
    public class AppleSpawner: MonoBehaviour
    {
        private ObjectPoole<Apple> _pooler;
        private Transform _player;
        private float _radiusSpawn;

        public void Initialize(Apple applePrefab, int appleCount, Transform player, float radiusSpawn)
        {
            _pooler = new ObjectPoole<Apple>();
            _pooler.CreatePool(applePrefab,appleCount,transform);
            _player = player;
            _radiusSpawn = radiusSpawn;

            SpawnApples(appleCount-1);
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

        private void OnEatenApple(Apple applej)
        {
            applej.EatApple -= OnEatenApple;
            SpawnApples(1);
        }
    }
}