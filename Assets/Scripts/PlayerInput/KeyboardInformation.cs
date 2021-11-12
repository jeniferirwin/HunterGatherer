using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HunterGatherer.PlayerInput
{
    public class KeyboardInformation : MonoBehaviour
    {
        public static bool leftPressed { get; private set; }
        public static bool rightPressed { get; private set; }
        public static bool upPressed { get; private set; }
        public static bool downPressed { get; private set; }

        public void OnWASD(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            leftPressed = false;
            rightPressed = false;
            upPressed = false;
            downPressed = false;
            if (value.x < 0)
            {
                leftPressed = true;
            }
            else if (value.x > 0)
            {
                Debug.Log("Right pressed");
                rightPressed = true;
            }
            
            if (value.y < 0)
            {
                downPressed = true;
            }
            else if (value.y > 0)
            {
                upPressed = true;
            }
        }
    }
}