using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    private bool inventarioEnabled;
    public GameObject inventario;
    private int totalSlots;
    private int enableSlots;
    private GameObject[] slot;
    public GameObject slotHolder;
    void Start()
    {
        totalSlots = slotHolder.transform.childCount;
        slot = new GameObject[totalSlots];
        for (int i = 0; i < totalSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<slot>().item == null)
            {
                slot[i].GetComponent<slot>().empty = true;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            VerInventario();
        }

    }
    public void VerInventario()
    {
        inventarioEnabled = !inventarioEnabled;
        if (inventarioEnabled == true)
        {
            inventario.SetActive(true);
        }
        else
        {
            inventario.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item")
        {
            GameObject itemPickedUP = other.gameObject;

            item item = itemPickedUP.GetComponent<item>();

            Additem(itemPickedUP, item.ID, item.type, item.descripcion, item.icon);
        }
    }
    public void Additem(GameObject Itemobject, int ItemID, string ItemType, string ItemDescription, Sprite ItemIcon)
    {
        for (int i = 0; i < totalSlots; i++)
        {
            if (slot[i].GetComponent<slot>().empty)
            {
                Itemobject.GetComponent<item>().pickedUp = true;
                slot[i].GetComponent<slot>().item = Itemobject;
                slot[i].GetComponent<slot>().ID = ItemID;
                slot[i].GetComponent<slot>().type = ItemType;
                slot[i].GetComponent<slot>().description = ItemDescription;
                slot[i].GetComponent<slot>().icon = ItemIcon;

                Itemobject.transform.parent = slot[i].transform;
                Itemobject.SetActive(false);
                slot[i].GetComponent<slot>().empty = false;
            }
        }
    }
}

