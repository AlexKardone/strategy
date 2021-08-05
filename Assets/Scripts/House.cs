using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private GameObject resources;

    public int residents;
    public int maxResidents;
    public int residentsAdd;

    float residentTime;

    public int product;
    public int productUse;
    float productTime;

    public int residentsDied;

    float dieTime;

    public int tax;
    public int taxAdd;

    float taxTime;

    private ResourcesController resourcesController;

    void Start()
    {
        resources = GameObject.FindGameObjectWithTag("resourcesController");
        resourcesController = resources.GetComponent<ResourcesController>();

        resourcesController.maxResidents += maxResidents;
        resourcesController.buildings += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (residents < 0)
        {
            residents = 0;
        }

        ResidentAdd();
        Product();
        Tax();
        ResidentDie();
    }

    void ResidentAdd()
    {
        residentTime += 1 * Time.deltaTime;
        if (residentTime >= residentsAdd
        && resourcesController.residents < resourcesController.maxResidents
        && residents < maxResidents)
        {
            residents += 1;
            resourcesController.residents += 1;
            residentTime = 0;
        }
    }

    void ResidentDie()
    {
        residentTime += 1 * Time.deltaTime;
        if (dieTime >= residentsDied)
        {
            residents -= 1;
            resourcesController.residents -= 1;
            dieTime = 0;
        }
    }

    void Product()
    {
        int allProduct;
        productTime += 1 * Time.deltaTime;
        if (productTime >= productUse)
        {
            allProduct = residents * product;
            if (allProduct <= resourcesController.suplies) resourcesController.suplies -= allProduct;
            else
            {
                while (allProduct > resourcesController.suplies)
                {
                    residents -= 1;
                    resourcesController.residents -= 1;
                    allProduct -= 1;
                }
            }
            allProduct = 0;
            productTime = 0;
        }
    }

    void Tax()
    {
        int allTax;
        taxTime += 1 * Time.deltaTime;
        if (taxTime >= taxAdd)
        {
            allTax = residents * tax;
            resourcesController.gold += allTax;
            allTax = 0;
            taxTime = 0;
        }
    }
}
