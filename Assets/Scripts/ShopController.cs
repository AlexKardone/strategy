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
    public bool storeBuilt;

    [Header("ErrorMessage")]
    public GameObject errorResources;
    public GameObject errorStore;

    private BuildManager GetBuildManager(int i)
    {
        return allCells.transform.GetChild(i).GetComponent<BuildManager>();
    }

    public void Cancel()
    {
        errorResources.SetActive(false);
        errorStore.SetActive(false);
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
        if (resourcesPanel.GetComponent<ResourcesController>().gold < 2000)
        {
            errorResources.SetActive(true);
            return;
        }

        for (int i = 0; i < allCells.transform.childCount; i++)
        {
            buildManager = GetBuildManager(i);
            if (buildManager.activeCell && !buildManager.building)
            {
                buildManager.SetBuild(house);
                resourcesPanel.GetComponent<ResourcesController>().gold -= 2000;
            }
        }
        Cancel();
    }

    public void BuildTower()
    {
        if (resourcesPanel.GetComponent<ResourcesController>().gold < 7000)
        {
            errorResources.SetActive(true);
            return;
        }

        for (int i = 0; i < allCells.transform.childCount; i++)
        {
            buildManager = GetBuildManager(i);
            if (buildManager.activeCell && !buildManager.building)
            {
                buildManager.SetBuild(tower);
                resourcesPanel.GetComponent<ResourcesController>().gold -= 7000;
            }
        }
        Cancel();
    }

    public void BuildStore()
    {
        if (storeBuilt)
        {
            errorStore.SetActive(true);
            return;
        }

        if (resourcesPanel.GetComponent<ResourcesController>().gold < 5000)
        {
            errorResources.SetActive(true);
            return;
        }

        for (int i = 0; i < allCells.transform.childCount; i++)
        {
            buildManager = GetBuildManager(i);
            if (buildManager.activeCell && !buildManager.building)
            {
                buildManager.SetBuild(store);
                storeBuilt = true;
                resourcesPanel.GetComponent<ResourcesController>().gold -= 5000;
            }
        }
        Cancel();
    }
}
