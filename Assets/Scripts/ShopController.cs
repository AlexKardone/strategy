using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [Header("Buildings")]
    public GameObject house;

    [Header("Other")]
    public GameObject shopPanel;
    public GameObject allCells;
    private BuildManager buildManager;
    public bool houseBool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private BuildManager GetBuildManager(int i)
    {
        return allCells.transform.GetChild(i).GetComponent<BuildManager>();
    }

    public void Cancel()
    {
        shopPanel.SetActive(false);

        for (int i = 0; i < allCells.transform.childCount; i++)
        {
            buildManager = GetBuildManager(i);
            if (buildManager.activeCell)
            {
                buildManager.activeCell = false;
                break;
            }
        }
    }

    public void BuildHouse()
    {
        if (houseBool) return;

        for (int i = 0; i < allCells.transform.childCount; i++)
        {
            buildManager = GetBuildManager(i);
            if (buildManager.activeCell && !buildManager.building)
            {
                buildManager.SetBuild(house);
                houseBool = false;
                break;
            }
        }
        shopPanel.SetActive(false);
    }
}
