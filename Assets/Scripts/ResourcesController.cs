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
    
    void Update()
    {
        resourcesText.text = "Residents: " + residents + "/" + maxResidents + " Gold: " + gold + " Suplies: " + suplies + "/" + maxSuplies +
        "\r\nWood: " + wood + "/" + maxWood + " Stones: " + stones + "/" + maxStones + " Buildings: " + buildings;
    }
}
