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

    [SerializeField]
    GameObject[] cocinas = new GameObject[3];
    void Start()
    {
        ncocina = 0;
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (colision == true)
        {

            if(Input.GetKeyDown(player.dejar))
            {
                if(player.Comandas[0] != 0)
                {
                    if(ncocina < 3)
                    {
                        if(player.Comandas[0]!=1)
                        {
                            pedido = player.Comandas[0];
                            player.Comandas[0] = 0;
                            player.Comandas[0] = player.Comandas[1];
                            player.Comandas[1] = player.Comandas[2];
                            player.Comandas[2] = 0;
                            player.numcomandas--;


                            cocinas[ncocina] = Instantiate(Contador);
                            ncocina++;

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
                        if (ncocina == 1)
                        {
                            cocinas[0].transform.position = new Vector3(8.73f, 4.19f, 1.26f);
                        }
                        else if (ncocina == 2)
                        {
                            cocinas[1].transform.position = new Vector3(8.73f, 4.19f, 0.24f);
                        }
                        else if (ncocina == 3)
                        {
                            cocinas[2].transform.position = new Vector3(8.73f, 4.19f, -0.94f);
                        }


                    }
                }
            }
            
            if (Input.GetKeyDown(player.coger))
            {
                if(player.Inventario[0]==0)
                {
                    if(cocinas[0].GetComponent<PedidosCocina>().listo == true)
                    {
                        player.Coger(cocinas[0].GetComponent<PedidosCocina>().pedido);
                        if(ncocina==1)
                        {
                            cocinas[0].GetComponent<PedidosCocina>().recogido = true;
                        }
                        else if (ncocina == 2)
                        {
                            cocinas[0].GetComponent<PedidosCocina>().recogido = true;
                            cocinas[0] = cocinas[1];
                            Destroy(cocinas[1]);

                            cocinas[0].transform.position = new Vector3(8.73f, 4.19f, 1.26f);

                        }
                        else if(ncocina == 2)
                        {
                            cocinas[0].GetComponent<PedidosCocina>().recogido = true;
                            cocinas[0] = cocinas[1];
                            cocinas[1] = cocinas[2];
                            Destroy(cocinas[2]);
                            

                            cocinas[0].transform.position = new Vector3(8.73f, 4.19f, 1.26f);
                            cocinas[1].transform.position = new Vector3(8.73f, 4.19f, 0.24f);
                        }
                        ncocina--;
                    }
                }

            }
        }
    }
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
