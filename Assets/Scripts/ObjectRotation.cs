using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 35;
    void Update()
    {
        transform.Rotate(Vector3.left * speed * Time.deltaTime);
    }
}
