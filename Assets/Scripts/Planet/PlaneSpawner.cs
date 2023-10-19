using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Planet
{
    public class PlaneSpawner: MonoBehaviour
    {
        private ObjectPoole<PlanePart> _pooler;
        private PlanePart _prevPlane;
        private int _planeCount = 0;
        private Vector3 _spawnPosition;
        private Queue<PlanePart> _planes;

        public void Initialize(PlanePart planePartPrefab, int countPlanes )
        {
            _pooler = new ObjectPoole<PlanePart>();
            _pooler.CreatePool(planePartPrefab, countPlanes, transform);
            _spawnPosition = transform.position;
            _planes = new Queue<PlanePart>();

            SpawnPlane(Vector3.zero, WorldSide.None);
        }

        private void SpawnPlane(Vector3 plusPosition, WorldSide side)
        {
            if (_planes.Count>=3)
            {
                _planes.Dequeue().Hide();
            }
            
            PlanePart currentPlane = _pooler.GetObject();
            _planes.Enqueue(currentPlane);
            currentPlane.CreateNewPlane += CreateNewPlanePart;
            currentPlane.Initialize(side);
            currentPlane.transform.position = _spawnPosition + plusPosition;
            _spawnPosition = currentPlane.transform.position;
        }

        private void CreateNewPlanePart(Vector3 position, PlanePart plane, WorldSide side)
        {
            SpawnPlane(position, side);
        }
    }
}