using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocina2 : MonoBehaviour
{
    [SerializeField]
    GameObject Contador;

    bool colision;
    Player player;
    public int pedido;
    int ncocina;
    GameObject vacio; //objeto que se quedara vacio siempre (esto es igual a un destroy)

    [SerializeField]
    GameObject[] cocinas = new GameObject[3]; //aray de objetos que estaran en la cocina. solo caben 3

    [SerializeField] Vector3[] positions = new Vector3[3];
    void Start()
    {
        ncocina = 0;
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        //se detecta si el personaje esta dentro del colider de la cocina con el OnTriggerEnter que cambia colision a true o false segun salga del trigger o entre
        if (colision == true)
        {
            //player.dejar es una variable creada en el script player que se coloca desde el motor 
            if(Input.GetKeyDown(player.dejar))
            {
                //se detecta que exista alguna comanda en el array del personaje
                if(player.Comandas[0] != 0)
                {
                    //se detecta si la cocina tiene menos de 3 objetos para poder añador otro puesto que esta tiene solo tres huecos
                    if(ncocina < 3)
                    {
                        /*esto es la creacion de los objetos dentro de la cocina sacando el dato pedido de el array de comandas de el player. como la cocina
                         no acepta zumo(que es el comandas = 1) hay que revisar uno a uno player comandas. espezando por el primero mirando a ver si es distinto 
                        de 0 o 1, si es asi pedido pasa a ser player.comanda[el numero por el que se llegue] y se recoloca el array comandas para que nuca quede 
                        un hueco(el hueco siemrope queda al final del array)*/
                        if(player.Comandas[0]!=1)
                        {
                            //se recoloca el array player.comandas(el hueco siempre queda al final)
                            pedido = player.Comandas[0];
                            player.Comandas[0] = 0;
                            player.Comandas[0] = player.Comandas[1];
                            player.Comandas[1] = player.Comandas[2];
                            player.Comandas[2] = 0;
                            player.numcomandas--;

                            //se crea un contador que es el objeto que tendra el temporizador y el pedido que se recogera
                            cocinas[ncocina] = Instantiate(Contador);
                            ncocina++;
                            //se vuelve a hacer con el comandas 1 y comandas 2 por si el primer objeto es igual a 1
                        }else if (player.Comandas[1] != 1 && player.Comandas[1] != 0)
                        {
                            pedido = player.Comandas[1];
                            player.Comandas[1] = 0;
                            player.Comandas[1] = player.Comandas[2];
                            player.Comandas[2] = 0;
                            player.numcomandas--;


                            cocinas[ncocina] = Instantiate(Contador);
                            ncocina++;

                        }else if (player.Comandas[2] != 1 && player.Comandas[2] != 0)
                        {
                            pedido = player.Comandas[2];
                            player.Comandas[2] = 0;
                            player.numcomandas--;


                            cocinas[ncocina] = Instantiate(Contador);
                            ncocina++;

                        }
                        //despues de cada accion de colocar objetos se recolocan en el mundo los contadores para que siempre esten ordenados
                        if (ncocina == 1)
                        {
                            cocinas[0].transform.position = positions[0];
                        }
                        else if (ncocina == 2)
                        {
                            cocinas[1].transform.position = positions[1];
                        }
                        else if (ncocina == 3)
                        {
                            cocinas[2].transform.position = positions[2];
                        }


                    }
                }
            }
            //player.coger es una variable creada en el script player que se coloca desde el motor 
            if (Input.GetKeyDown(player.coger))
            {
                //se revisa el inventrio del player para ver si es distinta de 0 puesto que si no es asi significa que esta lleno y no se pueden coger mas pedidos
                if(player.Inventario[0]==0)
                {
                    /*solo se puede coger el primer objeto que esta en la cocina y de ahi se coloca el 2 en el 1 y el 3 en el 2. el 3 
                     se sustituye por un objeto que he llamado vacio el cual no tiene nada, puesto que si simplemente destruia el objeto no me funcionaba */
                    if(cocinas[0].GetComponent<PedidosAnim>().listo == true)
                    {
                        //lo primero es, atraves de el metodo coger del player se guarda el pedido en el inventario del player 
                        player.Coger(cocinas[0].GetComponent<PedidosAnim>().pedido);
                        //aqui se mueven los objetos de la cocina en funcion de cuantos haya. tambien se llama a el animador de esos objetos para destruirlos
                        if(ncocina==1)
                        {
                            cocinas[0].GetComponent<PedidosAnim>().recogido = true;
                            cocinas[0] = vacio;
                        }
                        else if (ncocina == 2)
                        {
                            cocinas[0].GetComponent<PedidosAnim>().recogido = true;
                            cocinas[0] = cocinas[1];
                            cocinas[1] = vacio;

                            cocinas[0].transform.position = positions[0];

                        }
                        else if(ncocina == 3)
                        {
                            cocinas[0].GetComponent<PedidosAnim>().recogido = true;
                            cocinas[0] = cocinas[1];
                            cocinas[1] = cocinas[2];
                            cocinas[2] = vacio;


                            cocinas[0].transform.position = positions[0];
                            cocinas[1].transform.position = positions[1];
                        }
                        ncocina--;
                    }
                }

            }
        }
    }
    //aqui se detecta si el player esta colisionando o no
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colision = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colision = false;
        }
    }
}
