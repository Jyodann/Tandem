using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GridManager GridManager;
    public PanelManager PanelManager;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        GridManager = GetComponent<GridManager>();
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
    }
}