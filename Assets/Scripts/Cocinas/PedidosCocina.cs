using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedidosCocina : MonoBehaviour
{
    SpriteRenderer spriterender;
    [Header("----------Sprites----------")]
    [SerializeField]
    Sprite hamburgesa;
    [SerializeField]
    Sprite huevosPatata;
    [SerializeField]
    Sprite pollo;
    [SerializeField]
    Sprite paella;
    [SerializeField]
    Sprite tortilla;
    [SerializeField]
    Sprite temporizador;

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
        spriterender = GetComponent<SpriteRenderer>();
        cocina = FindObjectOfType<Cocina2>();

        pedido = cocina.pedido;
        spriterender.sprite = temporizador;

    }
    void Update()
    {
        if (time >= tiempoPreparar)
        {
            listo = true;
            Debug.Log(listo);
        }
        else { time += Time.deltaTime; }

        if(listo == true)
        {
            switch (pedido)
            {
                case 6:
                    spriterender.sprite = paella;
                    break;
                case 5:
                    spriterender.sprite = hamburgesa;
                    break;
                case 4:
                    spriterender.sprite = pollo;
                    break;
                case 3:
                    spriterender.sprite = tortilla;
                    break;
                case 2:
                    spriterender.sprite = huevosPatata;
                    break;

            }
        }
        if(recogido == true)
        {
            Destroy(this.gameObject);
        }
    }
}
