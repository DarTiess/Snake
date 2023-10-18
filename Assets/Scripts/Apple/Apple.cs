using UnityEngine;

namespace DefaultNamespace
{
    public class Apple: MonoBehaviour
    {
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}