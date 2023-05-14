using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dias : MonoBehaviour
{
    //este script se puede sustituir por animaciones por lo que mas adelante se hara
    //este script simplemente funciona con el numero de game.data.dia cambiando el sprite en funcion de esta variable
    GameManager game;
    [SerializeField]
    Sprite dia1;
    [SerializeField]
    Sprite dia2;
    [SerializeField]
    Sprite dia3;
    [SerializeField]
    Sprite dia4;
    [SerializeField]
    Sprite dia5;
    [SerializeField]
    Sprite dia6;

    [SerializeField]
    Image calendario;

    void Start()
    {
        game = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        
        switch (game.gameData.dia)
        {
            case 6:
                calendario.sprite = dia6;
                break;
            case 5:
                calendario.sprite = dia5;
                break;
            case 4:
                calendario.sprite = dia4;
                break;
            case 3:
                calendario.sprite = dia3;
                break;
            case 2:
                calendario.sprite = dia2;
                break;
            case 1:
                calendario.sprite = dia1;
                break;
        }
    }
}
