using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HunterGatherer.PlayerInput
{
    public class Panning : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed;

        private Vector2 moveInput;

        public void OnWASD(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        }

        private void Update()
        {
            transform.Translate(moveInput * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}