using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float speed;

    [SerializeField]
    AudioClip comprep, Pay;
    AudioSource Audio;

    public KeyCode coger;
    public KeyCode dejar;

    Animator MyAnimation;

    public int[] Comandas = new int[3];
    public int numcomandas;
    public int[] Inventario = new int[3];
    void Start()
    {
        numcomandas = 0;
        MyAnimation=GetComponent<Animator>();
        Audio = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")) * speed;
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        MyAnimation.SetFloat("horizontal",Input.GetAxisRaw("Vertical"));
        MyAnimation.SetFloat("vertical", Input.GetAxisRaw("Horizontal"));
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
        Audio.PlayOneShot(comprep);

        Inventario[0] = plato;
    }
}