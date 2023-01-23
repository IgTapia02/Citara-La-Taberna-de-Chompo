using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comidas : MonoBehaviour
{
    public int pedido;
    SpriteRenderer spriterender;
    public bool atendido;
    public bool mitadTiempo;
    public bool comiendo;

    int numcomiendo;
    float tiempo;

    [SerializeField]
    Sprite hamburgesa;
    [SerializeField]
    Sprite huevosPatata;
    [SerializeField]
    Sprite pollo;
    [SerializeField]
    Sprite paella;
    [SerializeField]
    Sprite zumo;
    [SerializeField]
    Sprite tortilla;//sprites de todas las comidas, de la exclamacion cuando esta esperando y la animacion cuando come el npc
    [SerializeField]
    Sprite Esperando1;
    [SerializeField]
    Sprite Esperando2;
    [SerializeField]
    Sprite comiendo1;
    [SerializeField]
    Sprite comiendo2;
    [SerializeField]
    Sprite comiendo3;

    void Start()
    {
        spriterender = GetComponent<SpriteRenderer>();//se inicializa el sprite render
        atendido = false;
        mitadTiempo = false;
        comiendo = false;
        numcomiendo = 1;//variable para cambiar la animacion cuando come

    }
    void Update()
    {
        if (numcomiendo == 0)
        {
            numcomiendo = 1;
        }
        //cambio de sprites para la animacion de comer
        if (comiendo == true)
        {
            tiempo += Time.deltaTime;
            if (tiempo >= 0.3f)
            {
                switch (numcomiendo)
                {
                    case 1:
                        numcomiendo = 2;
                        break;
                    case 2:
                        numcomiendo = 3;
                        break;
                    case 3:
                        numcomiendo = 1;
                        break;
                }
                tiempo = 0;
            }


            switch (numcomiendo)
            {
                case 1:
                    spriterender.sprite = comiendo1;
                    break;
                case 2:
                    spriterender.sprite = comiendo2;
                    break;
                case 3:
                    spriterender.sprite = comiendo3;
                    break;
            }
        }
        else
        {
            //se pone el pedido que se selecciono en el npc
            if (atendido == true)
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
                    case 1:
                        spriterender.sprite = zumo;
                        break;
                }
            }
            //animacion de antes de pedir con las exclamaciones
            else
            {
                if (mitadTiempo == true)
                {
                    spriterender.sprite = Esperando2;
                }
                else
                {
                    spriterender.sprite = Esperando1;
                }
            }
        }
    }

    //se pasa el pedido del npc al pedido de este script
    public int EstablecerPedido(int pedidoNPC)
    {
        pedido = pedidoNPC;

        return pedido;
    }



}
