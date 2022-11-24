using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[System.Serializable]

public class GameManager : MonoBehaviour
{
    [Header("Precios comida")]
    [SerializeField]
    int zumos,comidas;

    public GameData gameData;
    //public int dineroPJ = 0;
    public TMP_Text Dinero;
    //public int dia, semana;

    public static GameManager current;

    void Start()
    {
        gameData.dia = 1;
        gameData.semana = 1;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Dinero.text = gameData.dineroPJ + "$";
        Debug.Log(gameData.dia);
    }

    public void Pagar(int pedido)
    {
        if(pedido == 1)
        {
            gameData.dineroPJ += zumos;
        }
        if(pedido == 2 || pedido == 3 || pedido == 4 || pedido == 5)
        {
            gameData.dineroPJ += comidas;
        }
    }
}

[System.Serializable]
public class GameData
{
    public int dineroPJ = 0;
    public int dia, semana;

}