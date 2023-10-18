using System;
using UnityEngine;

namespace Planet
{
    public class TriggerObserver: MonoBehaviour
    {
        private WorldSide _side;
        public event Action<WorldSide> TriigeredPlayer;

        public void Initialize(WorldSide side)
        {
            _side = side;
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerContainer player))
            {
                TriigeredPlayer?.Invoke(_side);
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}