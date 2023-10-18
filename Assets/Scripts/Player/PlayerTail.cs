using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerTail: MonoBehaviour
    {
        private List<GameObject> _tailsPart;
        private float _snakeSpeed;

        public void Initialize(float snakeSpeed)
        {
            _snakeSpeed = snakeSpeed;
        }

        private void FixedUpdate()
        {
            if (_tailsPart.Count > 0)
            {
                MoveTail();
            }
        }
        
        private void MoveTail()
        {
            float sqrDistance = Mathf.Sqrt(5.5f);
            Vector3 prevPosition = transform.position;
            for(int i=0;i<_tailsPart.Count;i++)
            {
                if ((_tailsPart[i].transform.position - prevPosition).sqrMagnitude > sqrDistance)
                {
                   
                        if (i > 0)
                        { 
                            Vector3 relativePos = _tailsPart[i-1].transform.position - _tailsPart[i].transform.position;

                       
                            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                            _tailsPart[i].transform.rotation = rotation;
                            // gb.transform.(mansInside[indexOfMan--].transform.position);

                        }
                        else
                        {
                            Vector3 relativePos = transform.position - _tailsPart[i].transform.position;

                            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                            _tailsPart[i].transform.rotation = rotation;

                        }
                       
                        Vector3 smoothPos = Vector3.Lerp(_tailsPart[i].transform.position, prevPosition, _snakeSpeed * Time.deltaTime);


                        prevPosition = smoothPos;
                        Vector3 currentPos = _tailsPart[i].transform.position;

                        _tailsPart[i].transform.position = prevPosition;
                        prevPosition = currentPos;
                    
                }
            }



        }
        public void AddManInRange()
        {
            GameObject man;
            if (_tailsPart.Count > 0)
            {
                man= Instantiate(mansPrefab, _tailsPart[_tailsPart.Count - 1].transform.position, transform.rotation); 
         
            }
            else
            {
                man = Instantiate(mansPrefab, transform.position , transform.rotation);
          
            }
            man.transform.localScale = new Vector3(2f, 2f, 2f);

            man.GetComponent<Enemy>().number = indexMan;
            _tailsPart.Add(man);
        
            GameManager.Instance.AddMan();
            indexMan++;
            zPos += 2.5f;
            
            for (int i=0;i<_tailsPart.Count;i++)
            {
                _tailsPart[i].GetComponent<Enemy>().GrownAnimation();
            }
        }
    }
}