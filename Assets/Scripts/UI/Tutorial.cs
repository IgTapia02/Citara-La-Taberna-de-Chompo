using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    MenuPausa menupausa;
    GameManager gameManager;
    int numero;
    [SerializeField]
    Image sr;
    Sprite[] tuto = new Sprite[5];
    [SerializeField]
    Sprite primera;
    [SerializeField]
    Sprite segunda;
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
        gameManager = FindObjectOfType<GameManager>();
        tuto[0] = primera;
        tuto[1] = segunda;
        tuto[2] = tercera;
        tuto[3] = cuarta;
        tuto[4] = quinta;

    }
    void Update()
    {
        sr.sprite = tuto[numero];
    }

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

    public void anterior()
    {
        if (numero > 0)
        {
            numero--;
        }
    }
}
