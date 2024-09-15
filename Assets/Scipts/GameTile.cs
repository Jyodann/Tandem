using UnityEngine;

public abstract class GameTile : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;
    protected int x, y;
    public TileType TileType = TileType.None;

    public virtual void Initialise(int x, int y)
    {
        this.x = x;
        this.y = y;
        transform.position = new Vector2(x, y);
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
    }
}

public enum TileType
{
    None,
    Player,
    Background,
    Border,
    Exit,
    ColouredBarrierRed,
    ColouredBarrierBlue,
    EnemyTile
}