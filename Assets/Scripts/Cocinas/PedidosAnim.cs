using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedidosAnim : MonoBehaviour
{
    [SerializeField]
    Animator my_Animator;

    [SerializeField]
    float tiempoPreparar;

    private AudioSource my_AudioSource;

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
        my_AudioSource = GetComponent<AudioSource>();
        cocina = GetComponentInParent<Cocina2>();
        transform.localScale = new Vector3(0.25f, 0.383422226f, 0.516145289f);
        pedido = cocina.pedido;
        //temporizador antiguo
        //spriterender.sprite = temporizador;
        my_Animator = gameObject.GetComponent<Animator>();
        my_Animator.speed = 1/tiempoPreparar;  //igualar tiempo de pedido a la speed del animator=1   (1*x=tiempopedido) animación adaptativa al inicializar con el valor predefinido
        my_Animator.SetFloat("controladorTempo", 1);
    }
    void Update()
    {
        if (time >= tiempoPreparar)
        {
            listo = true;
            my_AudioSource.Play();
        }
        else { time += Time.deltaTime; }
        //se activan las animaciones a medida que el objeto contador este en una fase u otra
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