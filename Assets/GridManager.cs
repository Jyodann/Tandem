using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameTile tile, playerTile, exitTile, surrondingWallTile;

    [SerializeField] private List<TextAsset> levels;

    private Dictionary<Vector2, GameTile> tileGrid = new();

    private void Start()
    {
        GenerateGrid(0);
    }

    private void GenerateGrid(int lv_index)
    {
        var currentLevel = levels[lv_index];

        var lv_data = currentLevel.text;

        var row_data = lv_data.Split('\n').Reverse().ToArray();

        var width = row_data[0].Length;

        for (int y = -1; y < row_data.Length + 1; y++)
        {
            for (int x = -1; x < width + 1; x++)
            {
                var tileInstance = Instantiate(surrondingWallTile, new Vector2(x, y), Quaternion.identity);
                tileInstance.transform.parent = transform;
                tileInstance.Initialise(x, y);

                tileGrid[new Vector2(x, y)] = tileInstance;
            }
        }

        for (int y = 0; y < row_data.Length; y++)
        {
            var col_data = row_data[y].Split(',');

            for (int x = 0; x < width; x++)
            {
                var tile_info = col_data[x].Trim();
                GameTile tileInstance;

                switch (tile_info)
                {
                    case "P":
                        tileInstance = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
                        tileInstance = Instantiate(playerTile,
                            Vector2.zero, Quaternion.identity);
                        break;

                    case "E":
                        print("Exit");
                        tileInstance = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
                        tileInstance = Instantiate(exitTile,
                            Vector2.zero, Quaternion.identity);
                        break;

                    default:
                        tileInstance = Instantiate(tile, new Vector2(x, y), Quaternion.identity);

                        break;
                }

                tileInstance.name = $"Tile {x} {y} - {tile_info}";
                tileInstance.transform.parent = transform;
                tileInstance.Initialise(x, y);
                tileGrid[new Vector2(x, y)] = tileInstance;
            }
        }
    }
}