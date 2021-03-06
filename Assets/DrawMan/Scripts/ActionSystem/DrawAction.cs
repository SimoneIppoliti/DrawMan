using UnityEngine;
using UnityEngine.InputSystem;

namespace DrawMan.Core.ActionSystem
{
    [CreateAssetMenu(fileName = "New Draw Action", menuName = "Characters/Actions/Draw Action")]
    public class DrawAction : ScriptableObject
    {
        private Vector2 m_point;
        private Vector2 m_delta;
        private bool m_release;
        private bool m_press;

        public Vector2 Point => m_point;
        public Vector2 Delta => m_delta;
        public bool Touch => m_press && !m_release;

        public bool Release
        {
            get
            {
                var release = m_release;
                m_release = false;
                return release;
            }
        }

        public bool Press
        {
            get
            {
                var press = m_press;
                m_press = false;
                return press;
            }
        }

        public void OnTouch(InputAction.CallbackContext ctx)
        {
            m_press = ctx.ReadValueAsButton();
            m_release = !m_press;
        }

        public void OnPosition(InputAction.CallbackContext ctx)
        {
            m_point = ctx.ReadValue<Vector2>();
        }

        public void OnDelta(InputAction.CallbackContext ctx)
        {
            m_delta = ctx.ReadValue<Vector2>();
        }
    }
}
