using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class Tail: MonoBehaviour
    {
       
        private Transform _tailPosition;
        private float _speed;

        private void Update()
        {
            Move();
        }

        public void Initialize(Transform newTailPosition,  float speed)
        {
            _tailPosition = newTailPosition;
            _speed = speed;
            transform.SetPositionAndRotation(newTailPosition.position, newTailPosition.rotation);
           
            transform.DOScale(transform.localScale.x * 0.5f, 0.3f).SetLoops(2, LoopType.Yoyo);

        }

        private void Move()
        {
            Vector3 lookAtPosition = _tailPosition.position - transform.position;
            
            Quaternion rotation = Quaternion.LookRotation(lookAtPosition, Vector3.up);
            transform.rotation = rotation;
                     
            Vector3 smoothPos = Vector3.Lerp(transform.position, _tailPosition.transform.position, _speed * Time.deltaTime);

            transform.position= smoothPos;
        }
    }
}