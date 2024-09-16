using UnityEngine;
using static GridManager;

public class PanelManager : MonoBehaviour
{
    LevelData currentLevelData;

    [SerializeField] KeyGuide keyGuidePrefab;
    // Start is called before the first frame update

    public void DisplayItems()
    {
        currentLevelData = GameManager.Instance.GridManager.GetLevelData();

        if (currentLevelData.downArrowAction != CombinedAction.NONE)
        {
            var downArrowInstance = Instantiate(keyGuidePrefab, transform, false);
            downArrowInstance.Initialise(currentLevelData.downArrowAction, Vector2.down);
        }

        if (currentLevelData.upArrowAction != CombinedAction.NONE)
        {
            var downArrowInstance = Instantiate(keyGuidePrefab, transform, false);
            downArrowInstance.Initialise(currentLevelData.upArrowAction, Vector2.up);
        }

        if (currentLevelData.rightArrowAction != CombinedAction.NONE)
        {
            var downArrowInstance = Instantiate(keyGuidePrefab, transform, false);
            downArrowInstance.Initialise(currentLevelData.rightArrowAction, Vector2.right);
        }

        if (currentLevelData.leftArrowAction != CombinedAction.NONE)
        {
            var downArrowInstance = Instantiate(keyGuidePrefab, transform, false);
            downArrowInstance.Initialise(currentLevelData.leftArrowAction, Vector2.left);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
