using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TMP_Text Dinero;
    public TMP_Text Dia;

    GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Dinero.text = manager.gameData.dineroPJ + "$";
        Dia.text = "Dia: " + manager.gameData.dia;
    }
}
