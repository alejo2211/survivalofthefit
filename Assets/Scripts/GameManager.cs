using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
//En vez de monedas recursos de mejora.

public class GameManager : MonoBehaviour
{
    //De puntaje
    public TextMeshProUGUI tex_Count;
    int count_Coin;
    //Singleton
    public static GameManager gameManager { get; private set; }
    
    public UnitHealth _playerHealth = new UnitHealth(100, 100);
    //Puntaje y recursos

    void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }
    public void AddCoin()
    {
        count_Coin++;
        tex_Count.text = count_Coin.ToString();
    }

    //Sistema de Salud

}
