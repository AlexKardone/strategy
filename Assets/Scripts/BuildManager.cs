using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    private Image image;
    public bool building;
    public bool water;
    public GameObject shopPanel;

    private void Awake()
    {
        image = transform.GetChild(0).GetComponent<Image>();
    }

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    void Update()
    {
        if (shopPanel.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.Mouse0)
            && image.color == Color.green
            && !water)
        {
            shopPanel.SetActive(true);
        }
    }

    private void OnMouseEnter()
    {
        if (building) image.color = Color.red;
        else image.color = Color.green;
    }

    private void OnMouseExit()
    {
        image.color = Color.white;
    }
}
