using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float speed;

    [SerializeField]
    public KeyCode coger;

    [SerializeField]
    public KeyCode dejar;


    public int[] Comandas = new int[3];
    int numcomandas;
    public int[] Inventario = new int[3];
    int numplatos;
    void Start()
    {
        numcomandas = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.MovePosition(rigidbody.position + direction * speed * Time.deltaTime);

    }

    public void Apuntar(int comanda)
    {
        if(numcomandas<2)
        {
            Comandas[numcomandas] = comanda;
            numcomandas++;
        }
    }
    public void Coger(int plato)
    {
        if (numplatos < 2)
        {
            Comandas[numplatos] = plato;
            numplatos++;
        }
    }
}
