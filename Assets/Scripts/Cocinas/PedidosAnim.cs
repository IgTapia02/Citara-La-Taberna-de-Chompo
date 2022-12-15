using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedidosAnim : MonoBehaviour
{
    [SerializeField]
    Animator my_Animator;

    [SerializeField]
    float tiempoPreparar;


    float time;
    public bool listo;
    public bool recogido;
    public int pedido;
    Cocina2 cocina;

    void Start()
    {
        recogido = false;
        listo = false;
        time = 0;

        cocina = FindObjectOfType<Cocina2>();

        pedido = cocina.pedido;
        //temporizador antiguo
        //spriterender.sprite = temporizador;
        my_Animator = gameObject.GetComponent<Animator>();
        my_Animator.speed = 1/tiempoPreparar;  //iguaslar tiermpo de pedido a la speed del animator=1   (1*x=tiempopedido) animación adaptativa al inicializar con el valor predefinido
        my_Animator.SetFloat("controladorTempo", 1);
    }
    void Update()
    {
        if (time >= tiempoPreparar)
        {
            listo = true;
            Debug.Log(listo);
        }
        else { time += Time.deltaTime; }

        if (listo == true)
        {
            my_Animator.SetFloat("controladorTempo",pedido);
        }
        if (recogido == true)
        {
            Destroy(this.gameObject);
        }
    }
}