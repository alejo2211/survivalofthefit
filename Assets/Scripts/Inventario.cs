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
        }
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventarioEnabled = !inventarioEnabled;
        }
        if (inventarioEnabled == true)
        {
            inventario.SetActive(true);
        }
        else
        {
            inventario.SetActive(false);
        }
    }
}
