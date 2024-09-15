using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GridManager;

public class PanelManager : MonoBehaviour
{
    LevelData currentLevelData;
    // Start is called before the first frame update
    void Start()
    {
        currentLevelData = GameManager.Instance.GridManager.GetLevelData();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
