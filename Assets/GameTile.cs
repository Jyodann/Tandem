using UnityEngine;

public abstract class GameTile : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;
    protected int x, y;

    public virtual void Initialise(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = new Vector2(x, y);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    }
}