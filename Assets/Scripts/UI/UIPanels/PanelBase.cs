using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UIPanels
{
    public abstract class PanelBase : MonoBehaviour
    {
        [SerializeField] private Button _button;
        public virtual event Action ClickedPanel;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClickedPanel);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClickedPanel);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        protected virtual void OnClickedPanel()
        {
          
        }
    }
}