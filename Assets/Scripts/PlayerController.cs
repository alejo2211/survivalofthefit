 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;//variable publica del componente Animator
    public float speed = 5;//Variable publica de velocidad
    public float JumpForce = 10;
    Vector3 originalPosition;
    public float v;//-1----0----1 W,S
    public float h;//-1----0----1 A,D
    public Vector2 prueba;
    public Rigidbody Rig;
    public Vector3 rotacion;
    public float correr = 1.5f;
    public float health = 100;
    public Joystick j;
    public bool corriendo;
    AudioSource coin;
    AudioSource hit;
    // [hit.Play();] en el codigo de daño.
    //Añadir Sliders


    Vector3 originalPos;//COSA DE CLASE

    void Start()//Esta funcion se usa para inicializar (se ejecuta una sola vez)
    {
        originalPosition = transform.position;
        coin = GameObject.Find("Audios/Coin").GetComponent<AudioSource>();
        //hit = GameObject.Find("Audios/Hit").GetComponent<AudioSource>();
    }
    public void cambiarcorriendo(bool b)
    {
        corriendo = b;
    }
    //Esta funcion se actualiza una vez por frame
    void Update()
    {

        // da entrada y calcula la velocidad segun la tecla presionada 1 * time.deltatime * 5 que es la velocidad o speed
        h = (Input.GetAxis("Horizontal") + j.Horizontal) * Time.deltaTime * speed;// teclas A,D
        v = (Input.GetAxis("Vertical") + j.Vertical ) * Time.deltaTime * speed;// teclas W,S
        prueba = new Vector2(j.Horizontal, j.Vertical);

        // si se presiona la tecla shift va aumentar la velocidad
        if (Input.GetKey(KeyCode.LeftShift) || corriendo )
        {
            h = h * correr;
            v = v * correr;

        }
        // mueve el personaje hacia la direccion calculada respecto al mundo 
        Vector3 vel = new Vector3(h, 0, v);
        transform.Translate(vel, Space.World);

        // manda la -magnitud del vector velocidad- para el parametro velocidad del animator 
        anim.SetFloat("velocidad", vel.magnitude / Time.deltaTime);


        // el player mira hacia la ultima direccion o en el ultimo punto donde quedo
        rotacion = new Vector3(h, 0, v);
        if (rotacion.normalized.magnitude > 0.01f)
        {
            transform.forward = rotacion;
        }

        // si el personaje cae por debajo de -10 metros en y, el vuelve a la posicion original de donde aparece
        if (transform.position.y < -10)
        {
            transform.position = originalPosition;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Usar Objeto
        }

    }//Movimiento
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("CoinTemp"))
        {
            Destroy(other.gameObject);
            GameManager.gameManager.AddCoin();
            coin.Play();
            PlayerTakenDmg(20);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }
    }
    private void PlayerTakenDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
    }
    private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.DmgUnit(healing);
    }
}
