using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Player
{
    public class PlayerTail
    {
        private List<Tail> _tailsPart;
        private float _snakeSpeed;
        private ObjectPoole<Tail> _pooler;
        private Transform _headPosition;
        private Tail _tailPrefab;


        public PlayerTail(float snakeSpeed, Tail tailPrefab, int maxTailSize, Transform headPosition)
        {
            _snakeSpeed = snakeSpeed;
            _tailPrefab = tailPrefab;
            _headPosition = headPosition;
            _tailsPart = new List<Tail>(maxTailSize);
            _pooler = new ObjectPoole<Tail>();
            _pooler.CreatePool(tailPrefab, maxTailSize, null);
        }
        
        public void AddTailRange()
        {
            Tail tail = _pooler.GetObject();
            if (tail == null)
            {
                _pooler.CreatePool(_tailPrefab, _tailsPart.Count, null);
                tail = _pooler.GetObject();
            }
            Transform tailPosition = _headPosition;
            if (_tailsPart.Count>0)
            {
                tailPosition = _tailsPart[_tailsPart.Count - 1].transform;
            }

            tail.Initialize(tailPosition,_snakeSpeed);
               _tailsPart.Add(tail);
        }
    }
}