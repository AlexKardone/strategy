using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [Header("Buildings")]
    public GameObject house;
    public GameObject tower;
    public GameObject store;

    [Header("Other")]
    public GameObject shopPanel;
    public GameObject allCells;
    public GameObject resourcesPanel;
    private BuildManager buildManager;
    public bool houseBool;
    public bool towerBool;

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
        //if (houseBool) return;

        if (resourcesPanel.GetComponent<ResourcesController>().gold < 2000) return;

            for (int i = 0; i < allCells.transform.childCount; i++)
        {
            buildManager = GetBuildManager(i);
            if (buildManager.activeCell && !buildManager.building)
            {
                buildManager.SetBuild(house);
                //houseBool = true;
                resourcesPanel.GetComponent<ResourcesController>().gold -= 2000;
            }
        }
        shopPanel.SetActive(false);
    }

    public void BuildTower()
    {
        //if (towerBool) return;

        if (resourcesPanel.GetComponent<ResourcesController>().gold < 7000) return;

        for (int i = 0; i < allCells.transform.childCount; i++)
        {
            buildManager = GetBuildManager(i);
            if (buildManager.activeCell && !buildManager.building)
            {
                buildManager.SetBuild(tower);
                //towerBool = true;
                resourcesPanel.GetComponent<ResourcesController>().gold -= 7000;
            }
        }
        shopPanel.SetActive(false);
    }

    public void BuildStore()
    {
        //if (towerBool) return;

        if (resourcesPanel.GetComponent<ResourcesController>().gold < 5000) return;

        for (int i = 0; i < allCells.transform.childCount; i++)
        {
            buildManager = GetBuildManager(i);
            if (buildManager.activeCell && !buildManager.building)
            {
                buildManager.SetBuild(store);
                //towerBool = true;
                resourcesPanel.GetComponent<ResourcesController>().gold -= 5000;
            }
        }
        shopPanel.SetActive(false);
    }
}
