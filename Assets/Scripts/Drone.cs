using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Drone : MonoBehaviour
{
    
    public GameObject rot;

    
    void Update()
    {
        
        rot.transform.Rotate(Vector3.forward * 20);
    }
}
