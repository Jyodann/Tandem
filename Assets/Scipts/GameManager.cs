using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GridManager GridManager;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        GridManager = GetComponent<GridManager>();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}