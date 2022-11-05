using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    int speed;

    [SerializeField]
    GameObject colider;

    [SerializeField]
    public GameObject chair1, chair2, chair3, chair4;

    [SerializeField]
    float whaitimeantespedir;

    [SerializeField]
    float whaitimedespuespedir;
    
    public int pedido;

    bool existcolider;
    int state; // 0- entrando, 1- sentado esperando, 2-pidiendo, 3- esperando pedido,4- tomandopedido, 5- saliendo
    float tiempo;
    Player player;
    NPCManager manager;
    GameObject thisColider;
    void Start()
    {
        player = FindObjectOfType<Player>();
        manager = FindObjectOfType<NPCManager>();
        existcolider = false;
        tiempo = 0f;
        state = 0;
        speed = 5;
        chair1 = GameObject.Find("Chair (1)");
        chair2 = GameObject.Find("Chair (2)");
        chair3 = GameObject.Find("Chair (3)");
        chair4 = GameObject.Find("Chair (4)");
        target = manager.GetComponent<NPCManager>().target;
    }

    void Update()
    {
        if (state == 0)
        {
            Debug.Log("entrando");
            Move();
        }
        if(state == 1)
        {
            Debug.Log("esperandocomanda");
            Sentado();
        }
        /*if (state == 1)
        {
            tiempo += Time.deltaTime;
            Debug.Log(tiempo);
            if(tiempo > whaitimeantespedir)
            {
                tiempo = 0;
                state = 5;
            }
        }*/
        if(state == 2)
        {
            Debug.Log("pidiendo");
            Pedir();
        }
        if(state == 3)
        {
            Debug.Log("esperandopedido");
            Sentado2();
        }
        /*if (state == 3)
        {
            tiempo += Time.deltaTime;
            Debug.Log(tiempo);
            if (tiempo > whaitimedespuespedir)
            {
                tiempo = 0;
                state = 5;
            }
        }*/
        if(state == 4)
        {
            Debug.Log("comiendo");
            tiempo += Time.deltaTime;
            Debug.Log(tiempo);
            if (tiempo > 6)
            {
                tiempo = 0;
                state = 5;
            }
        }
        if (state == 5)
        {
            Debug.Log("marchandose");
            Move();
        }
    }

    void Move()
    {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }
    void Sentado()
    {
        
        if (existcolider == false)
        {
            thisColider = Instantiate(colider, transform);
            colider.transform.position = new Vector3(-3f, 0, 0);
            existcolider = true;
            
        }

        if(thisColider.GetComponent<NPCcolider>().atendido== true)
        {
            state = 2;
            Destroy(thisColider);
            existcolider = false;
        }


    }
    void Sentado2()
    {
        tiempo = 0;
        if (existcolider == false)
        {
            thisColider = Instantiate(colider, transform);
            colider.transform.position = new Vector3(-3f, 0, 0);
            existcolider = true;
        }

        if (thisColider.GetComponent<NPCcolider>().atendido == true)
        {
            if(player.Inventario[0] == pedido)
            {
                player.Inventario[0] = 0;
                Destroy(thisColider);
                existcolider = false;
                state = 4;
            }
            else
            {
                thisColider.GetComponent<NPCcolider>().atendido = false;
            }
        }
    }
    void Pedir()
    {
        tiempo = 0;
        pedido = Random.Range(1,6); //zumo
        player.Apuntar(pedido);
        state = 3;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Waypoint"))
        {
            if(state == 0)
            {
                target = other.gameObject.GetComponent<WayPoints>().point;
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
                target = other.gameObject.GetComponent<ChairManager>().Exitpoint;
            }
            if(state == 0)
            {
                if(chair1.GetComponent<Chair>().fill == false)
                {
                    chair1.GetComponent<Chair>().fill = true;
                    target = other.gameObject.GetComponent<ChairManager>().chair1;
                }
                else if (chair2.GetComponent<Chair>().fill == false)
                {
                    chair2.GetComponent<Chair>().fill = true;
                    target = other.gameObject.GetComponent<ChairManager>().chair2;
                }
                else if (chair3.GetComponent<Chair>().fill == false)
                {
                    chair3.GetComponent<Chair>().fill = true;
                    target = other.gameObject.GetComponent<ChairManager>().chair3;
                }
                else if (chair4.GetComponent<Chair>().fill == false)
                {
                    chair4.GetComponent<Chair>().fill = true;
                    target = other.gameObject.GetComponent<ChairManager>().chair4;
                }
                else
                {
                    state =  5;
                    target = other.gameObject.GetComponent<ChairManager>().Exitpoint;
                }

            }
        }
        if(other.CompareTag("Chair"))
        {
            if(state == 0)
            {
                target = other.gameObject.GetComponent<Chair>().exitpoint;
                transform.rotation = new Quaternion(0, 90, 0, 0);
                state = 1;
            }
        }
        if(other.CompareTag("Endpoint"))
        {
            if(state == 5)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
