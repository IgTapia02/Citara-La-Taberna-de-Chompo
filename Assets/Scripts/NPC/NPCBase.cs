using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCBase : MonoBehaviour
{
    public Transform target;

    [Header("Velocidad NPC")]
    [SerializeField]
    int speed;  //velocidad del npc

    [Header("Colider")]
    [SerializeField]
    GameObject colider; //colider para interactuar con el npc
    [SerializeField]
    GameObject comida; //objeto generado encima del npc que muestra la comida

    [Header("Sillas")]
    public GameObject chair1;
    public GameObject chair2; //sillas de la barra del restaurante
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

    bool existcolider;
    bool exclamacion;
    public int state; // estado en el que se encuantra el npc, todas las interacciones funcionan con estados
                      // 0- entrando, 1- sentado esperando, 2-pidiendo, 3- esperando pedido,4- tomandopedido, 5- saliendo
    float tiempo;
    Player player;
    GameManager pagar;
    NPCManager manager;
    GameObject thisColider;
    GameObject thisComida;
    GameObject ownchair;
    void Start()
    {
        pagar = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>(); //se inicializan todos los objetos que se van a utilizar
        manager = FindObjectOfType<NPCManager>();
        transform.position = manager.transform.position; //se coloca al npc en el punto fuera del restaurante para que entre
        existcolider = false;
        exclamacion = false;
        tiempo = 0f;
        state = 0;
        speed = 3;
        chair1 = GameObject.Find("Chair (1)");
        chair2 = GameObject.Find("Chair (2)");
        chair3 = GameObject.Find("Chair (3)"); // esto de las sillas lo pretendo cambiar a un array para poder añadir mas sillas en otros restaurantes posteriores
        chair4 = GameObject.Find("Chair (4)");
        target = manager.GetComponent<NPCManager>().target;// target sera el siguiente waypoint al que se movera el npc
        MyAnimation = GetComponent<Animator>();//se inicia el animator
        //las animaciones no estan puestas porque nos dio errores con el movimiento de waypoints
        //MyAnimation.Play("NPC1De");

    }

    void Update()
    {
        //en cada frame se revisa el estado en el que se encuentra el personaje y dependiendo de ello hara unas acciones u otras
        if (state == 0)
        {
            Move();
        }
        if(state == 1)
        {
            Sentado();
        }
        if (state == 1)
        {
            //contador del tiempo maximo que espera el cliente antes de que lo atiendas
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
            //contador del tiempo maximo que espera el cliente antes de que le des la comida
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
            //contador de tiempo que esta comiendo su pedido antes de irse 
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
            //MyAnimation.Play("NPC1Frente");
            Move();
        }
       
    }

    void Move()
    {
        //el movimiento se basa en que el npc mira hacia una direccion con su eje z y despues se le aplica una fuerza en este eje que lo mueve hasta colisionar con otro waypoint
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        MyAnimation.SetFloat("velx", this.speed);
        MyAnimation.SetFloat("vely", target.position.y);
        //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }

    //estado en el que se pide la comida
    void Sentado()
    {
        if(exclamacion == false)
        {
            thisComida = Instantiate(comida, transform);
            comida.transform.position = new Vector3(-0.21f, 1.07f, 0.67f);//posicion exacta encima de los npc para crear el bocadillo con la comida
            exclamacion = true;
        }
        if(tiempo >= (antesPedir/2))
        { 
            thisComida.GetComponent<Comidas>().mitadTiempo = true;    //esta es la animacion antes de ser atendido, esta se cambia desde el propio script del objeto y la variable mitadtiempo
        }
        else
        {
            thisComida.GetComponent<Comidas>().mitadTiempo = false;
        }
        //si no existe se genera un colider para poder interactuar con el npc
        if (existcolider == false)
        {
            thisColider = Instantiate(colider, transform);
            colider.transform.position = new Vector3(0, 0, 3f);
            existcolider = true;
            
        }
        //si hay algun hueco en las comandas del player y se ha interactuado con el colider (atendido1) se destruye este y se cambia de estado
        if(thisColider.GetComponent<NPCcolider>().atendido1== true && player.Comandas[2]==0)
        {
            Destroy(thisColider);
            existcolider = false;
            state = 2;
        }


    }
    //estado en el que se espera a recibir la comida
    void Sentado2()
    {
        //si no existe se genera un colider para poder interactuar con el npc
        if (existcolider == false)
        {
            thisColider = Instantiate(colider, transform);
            colider.transform.position = new Vector3(0, 0, 3f);
            existcolider = true;
        }
        //si se interactua con el colider(atendido2) se combrueba si en el inventario del player
        //esta el pedido de este npc, de ser asi el colider se destruye, se llama al metodo pagar
        //del game manager y se cambia de estado, si no se tiene lo que ha pedido el npc el atendido se cambia a false
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
    //estado en el que se pide la comida
    void Pedir()
    {
        pedido = Random.Range(1, 6);// se selecciona un pedido aleatorio entre 5
        thisComida.GetComponent<Comidas>().EstablecerPedido(pedido);// se coloca en el bocadillo encima de el npc el pedido indicado
        thisComida.GetComponent<Comidas>().atendido = true;//atendido pasa a ser verdadero para eliminar el npc
        player.Apuntar(pedido);// se guarda el pedido en el array comandas de player
        state = 3;// se cambia de etsado
        tiempo = 0;//se resetea a 0 el tiempo del contador 

    }


    private void OnTriggerEnter(Collider other)
    {
        //cada vez que se coolisione con un waypoint se enfoca al siguiente si esta entrando y al anterior si esta saliendo
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

        //en caunto colisiona con el chair manager hay dos opciones o que este saliendo y se vaya al punto de salida oq ue este entrando y tenga que sentarse en una
        //silla, si esta entrando hay que detectar que sillas estan libres empezando siempre desde la primera y comprobando todas hasta encontrar una vacia
        //cuando se encuentra, se cambia su variable fill a true y se pone su transform como target, si no se encuentra ninguna vacia se cambia el estado a 5 y se dirije al punto de salida
        if(other.CompareTag("Chairmanager"))
        {
            if(state == 5)
            {
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
                    state =  5;
                    target = other.gameObject.GetComponent<ChairManager>().Exitpoint;
                }

            }
        }
        //colision con las sillas
        if(other.CompareTag("Chair"))
        {
            MyAnimation.Play("Idlefrente");
            if (state == 0)
            {
                target = other.gameObject.GetComponent<Chair>().exitpoint;//se cambia el target a el punto de salida
                transform.rotation = new Quaternion(0f, 0.7071f, 0f, 0.7071f);//se centra el npc
                state = 1;//se cambia de estado
            }
        }
        //destrtuccion del personaje al llegar a el ultimo putno, despues de esto se suma uno en npccreados
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
