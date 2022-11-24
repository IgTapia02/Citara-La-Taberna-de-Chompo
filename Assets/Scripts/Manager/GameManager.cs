using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;
[System.Serializable]

public class GameManager : MonoBehaviour
{
    [Header("Precios comida")]
    [SerializeField]
    int zumos,comidas;

    public GameData data;

    public GameData gameData;
    //public int dineroPJ = 0;
    public TMP_Text Dinero;
    //public int dia, semana;

    void Start()
    {
        gameData.dineroPJ = 0;
        gameData.dia = 1;
        gameData.semana = 1;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Dinero.text = gameData.dineroPJ + "$";

        if(Input.GetKey(KeyCode.P))
        {
            Guardar();
        }
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
    
    public void Guardar()
    {
        data = new GameData();

        data.dia = gameData.dia;
        data.semana = gameData.semana;
        data.dineroPJ = gameData.dineroPJ;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, data);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            data = (GameData)bf.Deserialize(file);
            gameData = data;
            file.Close();
        }
    }
}

[System.Serializable]
public class GameData
{
    public int dineroPJ;
    public int dia, semana;

}