using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using static GridManager;

public class PlayerTile : GameTile
{
    [SerializeField] Bullet bulletPrefab;

    [SerializeField] List<Transform> locationOfBullet;
    LevelData currentLevelData;
    // Start is called before the first frame update
    protected override void Start()
    {
        currentLevelData = GameManager.Instance.GridManager.GetLevelData();
    }

    private void MovePlayer(Vector3 pos)
    {
        var directionToFace = transform.position - pos;
        transform.up = directionToFace;
        transform.position = pos;
    }

    private void ExecuteAction(CombinedAction action, Vector3 targetLocation)
    {
        switch (action)
        {
            case CombinedAction.SHOOT:
                Shoot(targetLocation);
                MovePlayer(targetLocation);

                break;
            case CombinedAction.MOVE:
                MovePlayer(targetLocation);
                break;
            case CombinedAction.SWAP_RED_BLUE:
                MovePlayer(targetLocation);
                SwapColor();
                break;
            default:
                break;
        }
    }

    private void Shoot(Vector3 posToFace)
    {

        var location = locationOfBullet[Random.Range(0, locationOfBullet.Count)];
        var directionToFace = transform.position - posToFace;
        var prefab = Instantiate(bulletPrefab, location.position, Quaternion.identity);

        prefab.transform.up = directionToFace;
        var rb2d = prefab.GetComponent<Rigidbody2D>();
        rb2d.velocity = prefab.transform.up * -20f;
    }

    private void SwapColor()
    {
        var gridManager = GameManager.Instance.GridManager;

        foreach (ColouredBarrierTile item in gridManager.redTiles)
        {
            item.SwapTile();
        }

        foreach (ColouredBarrierTile item in gridManager.blueTiles)
        {
            item.SwapTile();
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        var finalPos = transform.position;
        CombinedAction actionToExecute = CombinedAction.NONE;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            finalPos += Vector3.up;
            actionToExecute = currentLevelData.upArrowAction;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            finalPos += Vector3.down;
            actionToExecute = currentLevelData.downArrowAction;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            finalPos += Vector3.left;
            actionToExecute = currentLevelData.leftArrowAction;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            finalPos += Vector3.right;
            actionToExecute = currentLevelData.rightArrowAction;
        }

        if (finalPos == transform.position)
        {
            return;
        }

        var probedTile = GameManager.Instance.GridManager.ProbeLocation(finalPos);

        switch (probedTile.TileType)
        {
            case TileType.None:
                break;

            case TileType.Player:
                ExecuteAction(actionToExecute, finalPos);
                break;

            case TileType.Background:
                ExecuteAction(actionToExecute, finalPos);
                break;

            case TileType.Border:
                break;

            case TileType.Exit:
                MovePlayer(finalPos);
                ExecuteAction(actionToExecute, finalPos);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
            case TileType.ColouredBarrierBlue:
                if (((ColouredBarrierTile)probedTile).isEnabled)
                {
                    MovePlayer(finalPos);
                    ExecuteAction(actionToExecute, finalPos);
                }

                break;
            case TileType.ColouredBarrierRed:
                if (((ColouredBarrierTile)probedTile).isEnabled)
                {
                    MovePlayer(finalPos);
                    ExecuteAction(actionToExecute, finalPos);
                }

                break;
            default:
                break;
        }
    }
}