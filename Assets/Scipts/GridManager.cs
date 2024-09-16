using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.MPE;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int levelId = 0;
    [SerializeField]
    private GameTile tile, playerTile, exitTile,
        surrondingWallTile, woodenWallTile, enemyTile, blueTile, redTile, civillianTile;

    [SerializeField] public List<LevelData> levels;

    public List<GameTile> blueTiles;
    public List<GameTile> redTiles;

    public int NumberOfEnemies = 0;
    private readonly Dictionary<Vector2, GameTile> tileGrid = new();

    public GameTile ProbeLocation(Vector2 location)
    {
        if (tileGrid.ContainsKey(location))
        {
            return tileGrid[location];
        }
        else
        {
            return null;
        }
    }

    public void SetLocationType(Vector2 location)
    {
        tileGrid[location] = tile;
    }


    public LevelData GetLevelData()
    {
        return levels[levelId];
    }

    private void Start()
    {
        GenerateGrid(levelId);
        GameManager.Instance.PanelManager.DisplayItems();
    }

    [Serializable]
    public struct LevelData
    {
        public TextAsset levelLayoutData;
        public CombinedAction leftArrowAction;
        public CombinedAction rightArrowAction;
        public CombinedAction upArrowAction;
        public CombinedAction downArrowAction;
    }

    public enum CombinedAction
    {
        NONE,
        MOVE,
        SHOOT,

        SWAP_RED_BLUE
    }

    private void GenerateGrid(int lv_index)
    {
        blueTiles = new();
        redTiles = new();
        Transform playerLocation = null;
        List<Transform> enemyLocations = new();
        var currentLevel = levels[lv_index];

        var lv_data = currentLevel.levelLayoutData.text;

        var row_data = lv_data.Split('\n').Reverse().ToArray();

        var width = row_data[0].Split(',').Length;

        var cam_loc_y = row_data.Length;
        var cam_loc_x = row_data[0].Split(',').Length;

        Camera.main.transform.position = new Vector3(-1f, cam_loc_y / 2, -10f);
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

            for (int x = 0; x < col_data.Length; x++)
            {
                var tile_info = col_data[x].Trim();
                GameTile tileInstance;

                switch (tile_info)
                {
                    case "C":
                        tileInstance = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
                        tileInstance = Instantiate(civillianTile,
                            Vector2.zero, Quaternion.identity);
                        break;
                    case "B":
                        tileInstance = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
                        tileInstance = Instantiate(blueTile,
                            Vector2.zero, Quaternion.identity);
                        blueTiles.Add(tileInstance);
                        break;
                    case "R":
                        tileInstance = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
                        tileInstance = Instantiate(redTile,
                            Vector2.zero, Quaternion.identity);
                        redTiles.Add(tileInstance);
                        break;
                    case "P":
                        tileInstance = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
                        tileInstance = Instantiate(playerTile,
                            Vector2.zero, Quaternion.Euler(0, 0, 180f));
                        playerLocation = tileInstance.transform;
                        break;

                    case "X":
                        tileInstance = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
                        tileInstance = Instantiate(exitTile,
                            Vector2.zero, Quaternion.identity);
                        break;

                    case "W":
                        tileInstance = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
                        tileInstance = Instantiate(woodenWallTile,
                            Vector2.zero, Quaternion.identity);
                        break;
                    case "E":
                        tileInstance = Instantiate(tile, new Vector2(x, y), Quaternion.identity);
                        tileInstance = Instantiate(enemyTile,
                            Vector2.zero, Quaternion.identity);
                        enemyLocations.Add(tileInstance.transform);
                        NumberOfEnemies++;
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

        foreach (var item in enemyLocations)
        {
            item.transform.up = item.position - playerLocation.position;
        }
    }
}