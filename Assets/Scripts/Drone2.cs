using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone2 : MonoBehaviour
{
    public float velocidad;
    public Transform posicionObjetivo;
    public float frecuencia;
    public float amplitud;
    Vector3 desfase;
    public Transform personaje;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        desfase = Vector3.up * Mathf.Cos(Time.time * frecuencia) * amplitud;
        transform.position = Vector3.Lerp(transform.position, posicionObjetivo.position+desfase, velocidad * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, personaje.rotation, velocidad * Time.deltaTime);
    }
}
