using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionObjetos : MonoBehaviour
{
    public int curacion = 10;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
       
         {
            PlayerController.jugador.vida += curacion ;
            Destroy(gameObject);
            }
       

    }
}
