using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform chibi;
    public float velocidad = 5;

    public Vector3 diferencia;

    void Start()
    {
        diferencia = transform.position - chibi.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, chibi.position + diferencia, velocidad * Time.deltaTime); ;
        
    }
}
