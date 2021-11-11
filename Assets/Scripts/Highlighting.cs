using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class Highlighting : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;
    [SerializeField]
    private Grid grid;

    private Vector2 mousePosition;

    public void OnMouseover(InputAction.CallbackContext context)
    {
        mousePosition = (Vector3) context.ReadValue<Vector2>();
        var tilePos = map.WorldToCell(mousePosition);
        map.SetColor(tilePos, Color.blue);
    }

}
