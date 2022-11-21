using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Drone : MonoBehaviour
{
    public NavMeshAgent agente;
    Transform target;
    public GameObject rot;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        agente.SetDestination(target.position);
        rot.transform.Rotate(Vector3.forward * 20);
    }
}
