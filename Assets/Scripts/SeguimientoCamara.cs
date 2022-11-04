using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform chibi;
    public float velocidad = 5;
    public Joystick joy;
    public float velRotacion;

    
    public Transform referenciaCamara;

    void Start()
    {
       
        referenciaCamara.position = chibi.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        referenciaCamara.position = Vector3.Lerp(referenciaCamara.position, chibi.position, velocidad * Time.deltaTime); 
        referenciaCamara.Rotate(0,joy.Horizontal*velRotacion*Time.deltaTime,0);
    }
}
