using System;
using UnityEngine;

namespace Planet
{
    public class PlanePart : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _topTrigger;
        [SerializeField] private TriggerObserver _bottomTrigger;
        [SerializeField] private TriggerObserver _leftTrigger;
        [SerializeField] private TriggerObserver _rightTrigger;

        private float _size;

        public event Action<Vector3, PlanePart, WorldSide> CreateNewPlane; 

        private void OnEnable()
        {
            _size = transform.GetComponent<Renderer>().bounds.size.x;
           
            _topTrigger.Initialize(WorldSide.Top);
            _bottomTrigger.Initialize(WorldSide.Bottom);
            _leftTrigger.Initialize(WorldSide.Left);
            _rightTrigger.Initialize(WorldSide.Right);

            _topTrigger.TriigeredPlayer += OnTrigger;
            _bottomTrigger.TriigeredPlayer += OnTrigger;
            _leftTrigger.TriigeredPlayer += OnTrigger;
            _rightTrigger.TriigeredPlayer += OnTrigger;
        }

        private void OnDisable()
        {
            _topTrigger.TriigeredPlayer -= OnTrigger;
            _bottomTrigger.TriigeredPlayer -= OnTrigger;
            _leftTrigger.TriigeredPlayer -= OnTrigger;
            _rightTrigger.TriigeredPlayer -= OnTrigger;
        }

        public void Initialize(WorldSide side)
        {
            switch (side)
            {
                case WorldSide.Top:
                    _bottomTrigger.Hide();
                    break;
                case WorldSide.Bottom:
                    _topTrigger.Hide();
                    break;
                case WorldSide.Left:
                    _rightTrigger.Hide();
                    break;
                case WorldSide.Right:
                    _leftTrigger.Hide();
                    break;
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnTrigger(WorldSide sideType)
        {
            switch (sideType)
            {
                case WorldSide.Top:
                    CreateNewPlane?.Invoke(new Vector3(0,0,_size), this, WorldSide.Top);
                    break;
                case WorldSide.Bottom:
                    CreateNewPlane?.Invoke(new Vector3(0,0,-_size), this, WorldSide.Bottom);
                    break;
                case WorldSide.Left:
                    CreateNewPlane?.Invoke(new Vector3(-_size,0,0), this, WorldSide.Left);
                    break;
                case WorldSide.Right:
                    CreateNewPlane?.Invoke(new Vector3(_size,0,0),this, WorldSide.Right);
                    break;
            }
        }
    }
}