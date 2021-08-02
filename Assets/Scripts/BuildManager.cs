using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    private Image image;
    public bool building;
    public bool water;
    public bool activeCell;
    public GameObject shopPanel;
    private Transform obj;
    internal bool prop;

    private void Awake()
    {
        image = transform.GetChild(0).GetComponent<Image>();
    }

    void Update()
    {
        if (shopPanel.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.Mouse0)
            && image.color == Color.green
            && !water)
        {
            shopPanel.SetActive(true);
            activeCell = true;
        }
    }

    private void OnMouseEnter()
    {
        if (shopPanel.activeSelf) return;
        if (building) image.color = Color.red;
        else image.color = Color.green;
    }

    private void OnMouseExit()
    {
        image.color = Color.white;
    }

    public void SetBuild(GameObject build)
    {
        obj = Instantiate(build).transform;
        obj.position = transform.GetChild(1).transform.position;
        obj.Rotate(0, 0, 0);
        building = true;
        activeCell = false;
    }
}
