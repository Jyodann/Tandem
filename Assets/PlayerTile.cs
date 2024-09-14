using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTile : GameTile
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    private void MovePlayer(Vector2 pos)
    {
        transform.position = pos;
    }

    // Update is called once per frame
    private void Update()
    {
        var finalPos = transform.position;
        if (Input.GetKeyDown(KeyCode.W))
        {
            finalPos += Vector3.up;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            finalPos += Vector3.down;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            finalPos += Vector3.left;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            finalPos += Vector3.right;
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
                MovePlayer(finalPos);
                break;

            case TileType.Background:
                MovePlayer(finalPos);
                break;

            case TileType.Border:
                break;

            case TileType.Exit:
                MovePlayer(finalPos);
                print("You Win!");
                break;

            default:
                break;
        }
    }
}