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
    Sprite tortilla;
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
        spriterender = GetComponent<SpriteRenderer>();
        atendido = false;
        mitadTiempo = false;
        comiendo = false;
        numcomiendo = 1;

    }
    void Update()
    {
        Debug.Log(numcomiendo);
        Debug.Log(tiempo);
        if (numcomiendo == 0)
        {
            numcomiendo = 1;
        }

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

    public int EstablecerPedido(int pedidoNPC)
    {
        pedido = pedidoNPC;

        return pedido;
    }



}
