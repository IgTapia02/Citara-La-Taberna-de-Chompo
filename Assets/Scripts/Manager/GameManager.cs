using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
[System.Serializable]

public class GameManager : MonoBehaviour
{
    [Header("Precios comida")]
    [SerializeField]
    int zumos,comidas,pagoMes;

    string primerRestaurante = "MainRestaurant";
    public GameData data;

    public GameData gameData;


    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void NewGame()
    {
        gameData.dineroPJ = 0;
        gameData.dia = 1;
        gameData.semana = 1;
        SceneManager.LoadScene(primerRestaurante);
    }

    public void CambioDia()
    {
        gameData.dia++;
        if(gameData.dia>6)
        {
            gameData.semana++;
            gameData.dia = 1;
            gameData.dineroPJ -= pagoMes;
        }
        SceneManager.LoadScene("ResumeMenu");
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
    
    public void Save()
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
            SceneManager.LoadScene(primerRestaurante);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            data = (GameData)bf.Deserialize(file);
            gameData = data;
            file.Close();
        }
    }
    public void Salir()
    {
        Application.Quit();
    }
}

[System.Serializable]
public class GameData
{
    public int dineroPJ;
    public int dia, semana;

}