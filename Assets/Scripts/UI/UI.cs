using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //libreria de texto que utiliza el unity 3d

public class UI : MonoBehaviour
{
    public TMP_Text Dinero;
    public TMP_Text Dia;

    GameManager manager;
    //escribir por pantalla el dinero de ese dia y el dia en el que estamos
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Dinero.text = manager.dineroDia + "$";
        Dia.text = "" + manager.gameData.dia;
    }
}
