using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float speed;

    public KeyCode coger;
    public KeyCode dejar;


    public int[] Comandas = new int[3];
    public int numcomandas;
    public int[] Inventario = new int[3];
    void Start()
    {
        numcomandas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")) * speed;

    }

    public void Apuntar(int comanda)
    {
        if(numcomandas<=2)
        {
            Comandas[numcomandas] = comanda;
            numcomandas++;
        }
    }
    public void Coger(int plato)
    {
            Inventario[0] = plato;
    }
}