using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Apple: MonoBehaviour, IFood
    {
        public event Action<Apple> EatApple;

        public void Hide()
        {
            EatApple?.Invoke(this);
            gameObject.SetActive(false);
        }

       
    }
}