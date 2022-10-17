using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class splashscreen : MonoBehaviour
{
   public EasyTween Logo;

    void Start()
    {
     Logo.OpenCloseObjectAnimation();
     StartCoroutine("NextScene");
    }
     IEnumerator NextScene()
     {
          yield return new WaitForSeconds(2);
          SceneManager.LoadScene("Game");
     }
   
  
}
    