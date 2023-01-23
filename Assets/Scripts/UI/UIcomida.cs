using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcomida : MonoBehaviour
{
    //este script se puede sustituir por animaciones por lo que mas adelante se hara
    //este script simplemente funciona con los numeros de player.pedido y player.comandas cambiando los sprites en funcion de estas variables
    Player player;
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
    Sprite zumo;
    [SerializeField]
    Sprite hamburgesa2;
    [SerializeField]
    Sprite huevosPatata2;
    [SerializeField]
    Sprite pollo2;
    [SerializeField]
    Sprite paella2;
    [SerializeField]
    Sprite tortilla2;
    [SerializeField]
    Sprite zumo2;
    [SerializeField]
    Sprite nada;
    [SerializeField]
    Sprite nada2;

    [SerializeField]
    Image inventario;
    [SerializeField]
    Image comanda1;
    [SerializeField]
    Image comanda2;
    [SerializeField]
    Image comanda3;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        switch (player.Inventario[0])
        {
            case 6:
                inventario.GetComponent<Image>().enabled = true;
                inventario.sprite = paella2;
                break;
            case 5:
                inventario.GetComponent<Image>().enabled = true;
                inventario.sprite = hamburgesa2;
                break;
            case 4:
                inventario.GetComponent<Image>().enabled = true;
                inventario.sprite = pollo2;
                break;
            case 3:
                inventario.GetComponent<Image>().enabled = true;
                inventario.sprite = tortilla2;
                break;
            case 2:
                inventario.GetComponent<Image>().enabled = true;
                inventario.sprite = huevosPatata2;
                break;
            case 1:
                inventario.GetComponent<Image>().enabled = true;
                inventario.sprite = zumo2;
                break;
            case 0:
                inventario.GetComponent<Image>().enabled = false;
                inventario.sprite = nada2;
                break;
        }

        switch (player.Comandas[0])
        {
            case 6:
                comanda1.GetComponent<Image>().enabled = true;
                comanda1.sprite = paella;
                break;
            case 5:
                comanda1.GetComponent<Image>().enabled = true;
                comanda1.sprite = hamburgesa;
                break;
            case 4:
                comanda1.GetComponent<Image>().enabled = true;
                comanda1.sprite = pollo;
                break;
            case 3:
                comanda1.GetComponent<Image>().enabled = true;
                comanda1.sprite = tortilla;
                break;
            case 2:
                comanda1.GetComponent<Image>().enabled = true;
                comanda1.sprite = huevosPatata;
                break;
            case 1:
                comanda1.GetComponent<Image>().enabled = true;
                comanda1.sprite = zumo;
                break;
            case 0:
                comanda1.GetComponent<Image>().enabled = false;
                comanda1.sprite = nada;
                break;
        }
        switch (player.Comandas[1])
        {
            case 6:
                comanda2.GetComponent<Image>().enabled = true;
                comanda2.sprite = paella;
                break;
            case 5:
                comanda2.GetComponent<Image>().enabled = true;
                comanda2.sprite = hamburgesa;
                break;
            case 4:
                comanda2.GetComponent<Image>().enabled = true;
                comanda2.sprite = pollo;
                break;
            case 3:
                comanda2.GetComponent<Image>().enabled = true;
                comanda2.sprite = tortilla;
                break;
            case 2:
                comanda2.GetComponent<Image>().enabled = true;
                comanda2.sprite = huevosPatata;
                break;
            case 1:
                comanda2.GetComponent<Image>().enabled = true;
                comanda2.sprite = zumo;
                break;
            case 0:
                comanda2.GetComponent<Image>().enabled = false;
                comanda2.sprite = nada;
                break;
        }
        switch (player.Comandas[2])
        {
            case 6:
                comanda3.GetComponent<Image>().enabled = true;
                comanda3.sprite = paella;
                break;
            case 5:
                comanda3.GetComponent<Image>().enabled = true;
                comanda3.sprite = hamburgesa;
                break;
            case 4:
                comanda3.GetComponent<Image>().enabled = true;
                comanda3.sprite = pollo;
                break;
            case 3:
                comanda3.GetComponent<Image>().enabled = true;
                comanda3.sprite = tortilla;
                break;
            case 2:
                comanda3.GetComponent<Image>().enabled = true;
                comanda3.sprite = huevosPatata;
                break;
            case 1:
                comanda3.GetComponent<Image>().enabled = true;
                comanda3.sprite = zumo;
                break;
            case 0:
                comanda3.GetComponent<Image>().enabled = false;
                comanda3.sprite = nada;
                break;
        }
    }
}
