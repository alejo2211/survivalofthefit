using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victoria : MonoBehaviour
{
    public Inventario inventario;
    public GameObject letrero;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")

        {
            if (inventario.completado)
            {
                Invoke("CargarEscena", 2);
            }
            else
            {
                letrero.SetActive(true);
            }

        }


    }
    public void CargarEscena()
    {
        SceneManager.LoadScene("Victoria");
    }
}
