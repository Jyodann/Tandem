using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;

    [SerializeField] private GameTile tile;

    [SerializeField] private List<TextAsset> levels;

    private void Start()
    {
        GenerateGrid(0);
    }

    private void GenerateGrid(int lv_index)
    {
        var currentLevel = levels[lv_index];

        print(currentLevel.text);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var tileInstance = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
                tileInstance.name = $"Tile {x} {y}";
                tileInstance.transform.parent = transform;

                tileInstance.Initialise(x, y);
            }
        }
    }
}