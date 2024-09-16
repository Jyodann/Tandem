using UnityEngine;
using UnityEngine.UI;
using static GridManager;


public class KeyGuide : MonoBehaviour
{
    [SerializeField] Image spriteRenderer;

    [SerializeField] Image actionSpriteRenderer;
    [SerializeField] Sprite leftArrow, rightArrow, upArrow, downArrow;

    [SerializeField] Sprite swapRedBlue, gunShoot;
    public void Initialise(CombinedAction action, Vector2 direction)
    {

        if (action == CombinedAction.SHOOT)
        {
            actionSpriteRenderer.sprite = gunShoot;
        }

        if (action == CombinedAction.SWAP_RED_BLUE)
        {
            actionSpriteRenderer.sprite = swapRedBlue;
        }

        if (action == CombinedAction.MOVE)
        {
            actionSpriteRenderer.gameObject.SetActive(false);
        }
        if (direction == Vector2.up)
        {
            spriteRenderer.sprite = upArrow;
        }

        if (direction == Vector2.down)
        {
            spriteRenderer.sprite = downArrow;
        }

        if (direction == Vector2.left)
        {
            spriteRenderer.sprite = leftArrow;
        }

        if (direction == Vector2.right)
        {
            spriteRenderer.sprite = rightArrow;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
