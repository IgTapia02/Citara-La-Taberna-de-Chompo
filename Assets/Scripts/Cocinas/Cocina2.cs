using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocina2 : MonoBehaviour
{
    [SerializeField]
    GameObject Contador;

    bool colision;
    bool c1, c2, c3;
    Player player;
    int ncocina;

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
            if (Input.GetKeyDown(player.dejar))
            {
                if (player.Comandas[0] != 0 && ncocina<3)
                {
                    cocinas[ncocina] = Instantiate(Contador);
                    if(ncocina == 0)
                    {
                        c1 = true;
                    }
                    if (ncocina == 1)
                    {
                        c2 = true;
                    }
                    if (ncocina == 2)
                    {
                        c3 = true;
                    }
                    ncocina++;
                }
            }
            if (Input.GetKeyDown(player.coger))
            {
                if(cocinas[0].GetComponent<PedidosCocina>().listo == true && player.Inventario[0] == 0)
                {
                    player.Coger(cocinas[0].GetComponent<PedidosCocina>().pedido);
                    ncocina--;
                    Destroy(cocinas[0]);
                    cocinas[0] = cocinas[1];
                    cocinas[1] = cocinas[2];
                    Destroy(cocinas[2]);
                }

            }
        }
        cocinas[0].transform.position = new Vector3(8.73f, 4.19f, 1.26f);
        cocinas[1].transform.position = new Vector3(8.73f, 4.19f, 0.24f);
        cocinas[2].transform.position = new Vector3(8.73f, 4.19f, -0.94f);
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
