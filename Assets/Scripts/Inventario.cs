using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    private bool inventarioEnabled;
    public GameObject inventario;
    private int totalSlots;
    private int enableSlots;
    public Slot[] slot;
    public GameObject slotHolder;
    public bool completado;
    public GameObject explosion;
    void Start()
    {
        totalSlots = slotHolder.transform.childCount;
        
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

            item item = other.GetComponent<item>();

            Additem(itemPickedUP, item.ID, item.type, item.descripcion, item.icon);
            Instantiate(explosion, other.transform.position, other.transform.rotation);
        }
    }
    public void Additem(GameObject Itemobject, int ItemID, string ItemType, string ItemDescription, Sprite ItemIcon)
    {
        for (int i = 0; i < slot.Length; i++)
        {

            if (slot[i].empty)
            {
                Itemobject.GetComponent<item>().pickedUp = true;
                slot[i].item = Itemobject;
                slot[i].ID = ItemID;
                slot[i].type = ItemType;
                slot[i].description = ItemDescription;
                slot[i].icon = ItemIcon;

                Itemobject.transform.parent = slot[i].transform;
                Itemobject.SetActive(false);
                slot[i].UpdateSlot();
                slot[i].empty = false;
                if (i==slot.Length-1)
                {
                    completado = true;
                }
                return;            
            }
            
        }
    }
}

