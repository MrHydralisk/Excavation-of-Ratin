using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    [SerializeField]
    public GameObject mouseIndicator;
    [SerializeField]
    public GameObject cellIndicator;

    [SerializeField]
    private Grid grid;

    private void Start()
    {
        instance = this;
    }

    public Vector3Int WorldToCell(Vector3 positionWorld)
    {
        return grid.WorldToCell(positionWorld);
    }

    public Vector3 CellToWorld(Vector3Int positionCell)
    {
        return grid.CellToWorld(positionCell);
    }
}
