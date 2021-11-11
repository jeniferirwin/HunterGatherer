using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class Highlighting : MonoBehaviour
{
    public Tile[] tiles;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Tilemap map;
    [SerializeField]
    private Grid grid;
    
    private Vector2 mousePosition;
    private Vector3Int prevCell;
    private Vector3 worldPoint;
    
    public Color mouseOverColor;
    public Color mouseDownColor;
    private Color defaultColor = Color.white;

    private void Awake()
    {
        mousePosition = Vector3.zero;
        prevCell = Vector3Int.zero;
        //StartCoroutine(ReportDebugInfo());
    }

    public void OnMouseOver(InputAction.CallbackContext context)
    {
        mousePosition = (Vector3) context.ReadValue<Vector2>();
        // highlight tile
        var cell = CellFromMouse(mousePosition,map);
        if (prevCell != cell)
        {
            Highlight(prevCell, defaultColor);
            Highlight(cell, mouseOverColor);
            prevCell = cell;
        }
    }
    
    private void Highlight(Vector3Int cell, Color color)
    {
        map.SetColor(cell, color);
        map.RefreshTile(cell);
    }

    public void OnMouseDown(InputAction.CallbackContext context)
    {
        if (context.canceled) return;
        var cell = CellFromMouse(mousePosition, map);
        Highlight(cell, mouseDownColor);
        map.RefreshTile(cell);
    }
    
    public void OnMouseUp(InputAction.CallbackContext context)
    {
        if (!context.canceled) return;
        var cell = CellFromMouse(mousePosition,map);
        prevCell = cell;
        if (!map.HasTile(cell))
        {
            var rand = Random.Range(0,4);
            Debug.Log($"Setting new tile at {cell}: {tiles[rand].name}");
            map.SetTile(cell, tiles[rand]);
            map.RefreshTile(cell);
        }
        Highlight(cell, mouseOverColor);
    }

    private Vector3Int CellFromMouse(Vector2 pos, Tilemap tilemap)
    {    
        var worldPoint = cam.ScreenToWorldPoint(mousePosition);
        worldPoint.z = tilemap.transform.position.z;
        return tilemap.WorldToCell(worldPoint);
    }    

    private IEnumerator ReportDebugInfo()
    {
        for (;;)
        {
            Debug.Log(worldPoint);
            yield return new WaitForSeconds(1);
        }

    }
}
