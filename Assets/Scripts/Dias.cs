using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dias : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        
        switch (game.data.dia)
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
