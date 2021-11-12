using UnityEngine;

namespace HunterGatherer.PlayerInput
{
    public class Panning : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed;
        private Vector2 moveInput;

        private void Update()
        {
            moveInput = Vector2.zero;

            if (KeyboardInformation.leftPressed)
            {
                moveInput.x = -1;
            }
            if (KeyboardInformation.rightPressed)
            {
                moveInput.x = 1;
            }
            if (KeyboardInformation.upPressed)
            {
                moveInput.y = 1;
            }
            if (KeyboardInformation.downPressed)
            {
                moveInput.y = -1;
            }
        }

        private void LateUpdate()
        {
            transform.Translate(moveInput * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}