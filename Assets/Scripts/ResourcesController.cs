using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesController : MonoBehaviour
{
    public Text resourcesText;
    [Header("Resources")]
    public int residents;
    public int maxResidents;
    public int gold;
    public int suplies;
    public int maxSuplies;
    public int wood;
    public int maxWood;
    public int stones;
    public int maxStones;
    public int buildings;

    [Header("Error message")]
    public GameObject goldMessage;
    public GameObject woodMessage;
    public GameObject stoneMessage;

    void Update()
    {
        resourcesText.text = "Residents: " + residents + "/" + maxResidents + " Gold: " + gold + " Suplies: " + suplies + "/" + maxSuplies +
        "\r\nWood: " + wood + "/" + maxWood + " Stones: " + stones + "/" + maxStones + " Buildings: " + buildings;

        if (suplies < 0)
        {
            suplies = 0;
        }

        if (residents < 0)
        {
            residents = 0;
        }

        if (gold < 2000) goldMessage.SetActive(true);
        else goldMessage.SetActive(false);

        if (wood < 2000) woodMessage.SetActive(true);
        else goldMessage.SetActive(false);

        if (stones < 2000) stoneMessage.SetActive(true);
        else goldMessage.SetActive(false);
    }
}
