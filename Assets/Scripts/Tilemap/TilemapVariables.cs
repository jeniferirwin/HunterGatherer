using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[ExecuteInEditMode]
public class TilemapVariables : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private int width;
    [SerializeField] private int height;
    public Vector3Int[] cells;
    
    private void Start()
    {
        PopulateCellArray();
    }

    private void ShowCells()
    {
        
    }
    
    public void PopulateCellArray()
    {
        cells = new Vector3Int[width * height];    
        int i = 0;
        for (int y = 0; y < width; y++)
        {
            for (int x = 0; x < height; x++)
            {
                var pos = new Vector3Int(x,y,0);
                cells[i] = pos;
                i++;
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        foreach (var cell in cells)
        {
            Gizmos.DrawIcon(grid.CellToWorld(cell),"RegisteredCell",true);
        }
    }
}
