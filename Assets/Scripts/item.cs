using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public int ID;
    public string  type;
    public string descripcion;
    public Sprite icon;
    [HideInInspector]
    public bool pickedUp;
}
