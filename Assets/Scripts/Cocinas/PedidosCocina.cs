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
    float tiempoPreparar;


    float time;
    Player player;

    public int pedido;
    public bool listo;


    void Start()
    {
        listo = false;
        time = 0;
        player = FindObjectOfType<Player>();
        spriterender = GetComponent<SpriteRenderer>();
        pedido = player.Comandas[0];
        player.Comandas[0] = 0;
        player.Comandas[0] = player.Comandas[1];
        player.Comandas[1] = player.Comandas[2];
        player.Comandas[2] = 0;
        player.numcomandas--;

    }
    void Update()
    {
        if (time >= tiempoPreparar)
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
            listo = true;
            Debug.Log(listo);
        }
        else { time += Time.deltaTime; }
    }
}
