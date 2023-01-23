using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    //con este script pasa lo mismo que con el UIcomida que se puede cambiar por una animacion,
    //tambien teniamos pensado cambiar la forma de hacer el tutorial asique este script se borrara
    MenuPausa menupausa;
    int numero;
    [SerializeField]
    Image sr;
    Sprite[] tuto = new Sprite[5];
    [SerializeField]
    Sprite primera;
    [SerializeField]
    Sprite segunda;                  //array con todos los sprites del tutorial
    [SerializeField]
    Sprite tercera;
    [SerializeField]
    Sprite cuarta;
    [SerializeField]
    Sprite quinta;
    void Start()
    {
        numero = 0;
        menupausa = FindObjectOfType<MenuPausa>();
        tuto[0] = primera;
        tuto[1] = segunda;
        tuto[2] = tercera;
        tuto[3] = cuarta;
        tuto[4] = quinta;
        //se colocan los sprites

    }
    void Update()
    {
        sr.sprite = tuto[numero]; //se muestra la imagen indicada en el array tuto
    }

    //funcion que suma uno a numero para avanzar en el array, maximo de cuatro puesto que hay solo cincom imagenes
    public void siguiente()
    {
        if (numero < 4)
        {
            numero++;
        }
        else
        {
            menupausa.FinTutorial();
        }
    }

    //funcion que resta uno a numero para retroceder en el array
    public void anterior()
    {
        if (numero > 0)
        {
            numero--;
        }
    }
}
