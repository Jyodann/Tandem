using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTile : GameTile
{
    [SerializeField] protected Color baseColor, offsetColor;

    protected override void Start()
    {
        base.Start();
        var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
        spriteRenderer.color = isOffset ? baseColor : offsetColor;
    }
}