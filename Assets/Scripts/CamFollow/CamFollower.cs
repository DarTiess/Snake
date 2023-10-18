using System;
using Infrastructure.Level;
using UnityEngine;

namespace CamFollow {
    public class CamFollower : MonoBehaviour
    {
        [SerializeField] private float _distance = 2;
        [SerializeField] private float _height = 2;
        [SerializeField] private float _heightDamping = 2;
        [SerializeField] private float _rotationDamping = 0.6f;

       
        [Space][Space]  
        [SerializeField] private bool _dropTarget;
        

        private Transform _target;
        private Vector3 _temp;

        private LevelAction _levelAction;

        public void Initialize(LevelAction levAction, Transform player)
        {
            _levelAction = levAction;
            _target = player;
            _levelAction.OnLevelWin += OnLevelWin;
            _levelAction.OnLevelLost += OnLevelLost;
        } 
    
        private void OnLevelWin()               
        {
          
        }
        private void OnLevelLost()
        {
            SetStop();
        }
        private void LateUpdate()   
        {                 
            if (!_target) 
                return;
            MoveFollow();
        }
        
        private void MoveFollow()    
        {

            float wantedRotationAngle = _target.eulerAngles.y;
            float wantedHeight = _target.position.y + _height;

            float currentRotationAngle = transform.eulerAngles.y;
            float currentHeight = transform.position.y;

            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, _rotationDamping * Time.deltaTime);
       
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, _heightDamping * Time.deltaTime);
       
            Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
       
            transform.position = _target.position;
            transform.position -= currentRotation * Vector3.forward * _distance;  
       
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);    

            transform.LookAt(_target);     
        }

        public void SetStop()
        {
            if(!_dropTarget) return;  
            _target = null;  
        }

    }
}