using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCBase : MonoBehaviour
{
    public Transform target;

    [Header("Velocidad NPC")]
    [SerializeField]
    int speed;

    [Header("Colider")]
    [SerializeField]
    GameObject colider;
    [SerializeField]
    GameObject comida;

    [Header("Sillas")]
    public GameObject chair1;
    public GameObject chair2;
    public GameObject chair3;
    public GameObject chair4;

    [Header("Tiempos que espera antes de irse")]
    [SerializeField]
    float antesPedir;

    [SerializeField]
    float despuesPedir;

    [SerializeField]
    float comiendo;
    Animator MyAnimation;

    [Header("Pedido que realiza")]
    public int pedido;

    Rigidbody rb;
    bool existcolider;
    bool exclamacion;
    public int state; // 0- entrando, 1- sentado esperando, 2-pidiendo, 3- esperando pedido,4- tomandopedido, 5- saliendo
    float tiempo;
    Player player;
    GameManager pagar;
    NPCManager manager;
    GameObject thisColider;
    GameObject thisComida;
    GameObject ownchair;
    void Start()
    {
        pedido = Random.Range(1, 6);
        pagar = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        manager = FindObjectOfType<NPCManager>();
        transform.position = manager.transform.position;
        existcolider = false;
        exclamacion = false;
        tiempo = 0f;
        state = 0;
        speed = 3;
        chair1 = GameObject.Find("Chair (1)");
        chair2 = GameObject.Find("Chair (2)");
        chair3 = GameObject.Find("Chair (3)");
        chair4 = GameObject.Find("Chair (4)");
        target = manager.GetComponent<NPCManager>().target;
        MyAnimation = GetComponent<Animator>();
        MyAnimation.Play("NPC1De");
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (state == 0)
        {
            Move();
            //transform.rotation = new Quaternion(0f, 0.7071f, 0f, 0.7071f);
        }
        if(state == 1)
        {
            Sentado();
        }
        if (state == 1)
        {
            tiempo += Time.deltaTime;
            if(tiempo > antesPedir)
            {
                tiempo = 0;
                state = 5;
                Destroy(thisComida);
                Destroy(thisColider);
            }
        }
        if(state == 2)
        {
            Pedir();
        }
        if(state == 3)
        {
            Sentado2();
        }
        if (state == 3)
        {
            tiempo += Time.deltaTime;
         
            if (tiempo > despuesPedir)
            {
                tiempo = 0;
                state = 5;
                Destroy(thisComida);
            }
        }
        if(state == 4)
        {
            tiempo += Time.deltaTime;
            
            if (tiempo > comiendo)
            {
                tiempo = 0;
                state = 5;
                Destroy(thisComida);
            }
        }
        if (state == 5)
        {
            MyAnimation.Play("NPC1Frente");
            Move();
        }
       
    }

    void Move()
    {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

        //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }
    void Sentado()
    {
        if(exclamacion == false)
        {
            thisComida = Instantiate(comida, transform);
            comida.transform.position = new Vector3(-0.21f, 1.07f, 0.67f);
            exclamacion = true;
        }
        if(tiempo >= (antesPedir/2))
        { 
            thisComida.GetComponent<Comidas>().mitadTiempo = true;
        }
        else
        {
            thisComida.GetComponent<Comidas>().mitadTiempo = false;
        }
        if (existcolider == false)
        {
            thisColider = Instantiate(colider, transform);
            colider.transform.position = new Vector3(0, 0, 3f);
            existcolider = true;
            
        }

        if(thisColider.GetComponent<NPCcolider>().atendido1== true && player.Comandas[2]==0)
        {
            Destroy(thisColider);
            existcolider = false;
            state = 2;
        }


    }
    void Sentado2()
    {
        if (existcolider == false)
        {
            thisColider = Instantiate(colider, transform);
            colider.transform.position = new Vector3(0, 0, 3f);
            existcolider = true;
        }

        if (thisColider.GetComponent<NPCcolider>().atendido2 == true)
        {
            if(player.Inventario[0] == pedido)
            {
                player.Inventario[0] = 0;
                pagar.Pagar(pedido);
                Destroy(thisColider);
                thisComida.GetComponent<Comidas>().comiendo = true;
                existcolider = false;
                state = 4;
                tiempo = 0;
            }
            else
            {
                thisColider.GetComponent<NPCcolider>().atendido2 = false;
            }
        }
    }
    void Pedir()
    {
        tiempo = 0;
        thisComida.GetComponent<Comidas>().EstablecerPedido(pedido);
        thisComida.GetComponent<Comidas>().atendido = true;
        player.Apuntar(pedido);
        state = 3;
        tiempo = 0;

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Waypoint"))
        {
            if(state == 0)
            {
                target = other.gameObject.GetComponent<WayPoints>().point;
                Debug.Log(target);
            }
            if(state == 5)
            {
                target = other.gameObject.GetComponent<WayPoints>().Exitpoint;
            }
        }

        if(other.CompareTag("Chairmanager"))
        {
            if(state == 5)
            {
                Debug.Log("hola");
                MyAnimation.Play("NPC1Iz");
                target = other.gameObject.GetComponent<ChairManager>().Exitpoint;
                ownchair.GetComponent<Chair>().fill = false;
            }
            if(state == 0)
            {
                MyAnimation.Play("NPC1atr");
                if (chair1.GetComponent<Chair>().fill == false)
                {
                    chair1.GetComponent<Chair>().fill = true;
                    target = other.gameObject.GetComponent<ChairManager>().chair1;
                    ownchair = chair1;
                }
                else if (chair2.GetComponent<Chair>().fill == false)
                {
                    chair2.GetComponent<Chair>().fill = true;
                    target = other.gameObject.GetComponent<ChairManager>().chair2;
                    ownchair = chair2;
                }
                else if (chair3.GetComponent<Chair>().fill == false)
                {
                    chair3.GetComponent<Chair>().fill = true;
                    target = other.gameObject.GetComponent<ChairManager>().chair3;
                    ownchair = chair3;
                }
                else if (chair4.GetComponent<Chair>().fill == false)
                {
                    chair4.GetComponent<Chair>().fill = true;
                    target = other.gameObject.GetComponent<ChairManager>().chair4;
                    ownchair = chair4;
                }
                else
                {
                    Debug.Log("primero");
                    state =  5;
                    target = other.gameObject.GetComponent<ChairManager>().Exitpoint;
                }

            }
        }
        if(other.CompareTag("Chair"))
        {
            MyAnimation.Play("Idlefrente");
            if (state == 0)
            {
                Debug.Log("hola");
                target = other.gameObject.GetComponent<Chair>().exitpoint;
                transform.rotation = new Quaternion(0f, 0.7071f, 0f, 0.7071f);
                state = 1;
            }
        }
        if(other.CompareTag("Endpoint"))
        {
            if(state == 5)
            {
                
                manager.npcCreados++;
                
                Destroy(this.gameObject);
            }
        }
    }
}
