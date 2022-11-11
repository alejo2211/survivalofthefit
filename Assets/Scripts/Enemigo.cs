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
    public float dps;
    public Animator animaciones;
    public Transform[] checkPoints;
    Transform cpActual;
    public int indicecp;

  
    // Start is called before the first frame update
    void Start()
    {
        animaciones = GetComponent<Animator>();
        indicecp = Random.Range(0, checkPoints.Length);
        ElegirPunto();
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
        animaciones.SetFloat("velocidad", 1);
        if (distancia < distanciaSeguir)
        {
            estado = Estados.seguir;
        }
        agente.SetDestination(cpActual.position);
        if ((transform.position - cpActual.position).magnitude<4)
        {
            ElegirPunto();

        }
    }


    void EstadoSeguir()
    {
        animaciones.SetFloat("velocidad", 10);
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
        animaciones.SetFloat("velocidad", 0);
        animaciones.SetTrigger("ataque1");
        PlayerController.jugador.vida -= dps * Time.deltaTime;
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
        animaciones.SetTrigger("muerto");                  
        this.enabled = false;
    }
    void ElegirPunto()
    {
        indicecp += 1;
        if (indicecp>=checkPoints.Length)
        {
            indicecp = 0;
        }
        cpActual = checkPoints[indicecp];
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("palo"))
        {
            vida--;
        }
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