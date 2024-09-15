using UnityEngine;
using static GridManager;

public class PlayerTile : GameTile
{
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
                print("You Win!");
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