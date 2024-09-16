using UnityEngine;

public class ColouredBarrierTile : GameTile
{
    SpriteRenderer renderer;
    [SerializeField] public bool isEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        SwapTile();
    }

    public void SwapTile()
    {

        var alphaValue = isEnabled ? 1f : 0.2f;
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, alphaValue);
        isEnabled = !isEnabled;
    }

    // Update is called once per frame
    protected override void Update()
    {

    }
}
