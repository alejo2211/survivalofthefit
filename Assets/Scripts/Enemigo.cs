using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
   
{
    public float distanciaSeguir;
    public float distanciaAtacar;
    public Estados estado;
    public float distancia;
    public PlayerController jugador;
    public float vida;
    public NavMeshAgent agente;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalcularDistancia();
        switch (estado)
        {
            case Estados.idle:
                EstadoIdle();
                break;
            case Estados.seguir:
                EstadoSeguir();
                break;
            case Estados.atacar:
                EstadoAtacar();
                break;
            case Estados.muerto:
                EstadoMuerto();
                break;
            default:
                break;
        }
    }
    void EstadoIdle()
    {
        if (distancia < distanciaSeguir)
        {
            estado = Estados.seguir;
        }
    }
    void EstadoSeguir()
    {
        if (distancia < distanciaAtacar)
        {
            estado = Estados.atacar;
        }
        if (vida<=0)
        {
            estado = Estados.muerto;
        }
        agente.SetDestination(jugador.transform.position);
    }
    void EstadoAtacar()
    {
        if (vida <= 0)
        {
            estado = Estados.muerto;
        }
        if (distancia> distanciaAtacar +0.2f)
        {
            estado = Estados.seguir;
        }
    }
    void EstadoMuerto()
    {

    }
    void CalcularDistancia()
    {
        distancia = (transform.position - jugador.transform.position).magnitude;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaSeguir);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaAtacar);
    }
}

//[System.Serializable] 
public enum Estados
{
    idle = 0,
    seguir = 1,
    atacar = 2,
    muerto = 3

}