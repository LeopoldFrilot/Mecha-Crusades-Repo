using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FightingGame.Player
{
    public class InputReader : MonoBehaviour
    {
        InputManager IM;
        public void Start()
        {
            IM = GetComponent<InputManager>();
        }
        public void IHorizontal(InputAction.CallbackContext context)
        {
            if(context.ReadValue<float>() < -Mathf.Epsilon)
            {
                IM.Left();
            }
            else if(context.ReadValue<float>() > Mathf.Epsilon)
            {
                IM.Right();
            }
            else
            {
                IM.Neutral("Horizontal");
            }
        }
        public void IVertical(InputAction.CallbackContext context)
        {
            if (context.ReadValue<float>() < 0)
            {
                IM.Down();
            }
            else if (context.ReadValue<float>() > 0)
            {
                IM.Up();
            }
            else
            {
                IM.Neutral("Vertical");
            }
        }
        public void IJump(InputAction.CallbackContext context)
        {
            if (CheckButton(context)) { IM.Jump(); }
        }
        public void IDash(InputAction.CallbackContext context)
        {
            if (CheckButton(context)) { IM.Dash(); }
        }
        public void ILightAttack(InputAction.CallbackContext context)
        {
            if (CheckButton(context)) { IM.LightAttack(); }
        }
        public void IMediumAttack(InputAction.CallbackContext context)
        {
            if (CheckButton(context)) { IM.MediumAttack(); }
        }
        public void IHeavyAttack(InputAction.CallbackContext context)
        {
            if (CheckButton(context)) { IM.HeavyAttack(); }
        }
        private static bool CheckButton(InputAction.CallbackContext context)
        {
            return context.performed;
        }
    }
}

