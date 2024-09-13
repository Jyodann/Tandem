using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;

    [SerializeField] private GameTile tile;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var tileInstance = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
                tileInstance.name = $"Tile {x} {y}";
            }
        }
    }
}