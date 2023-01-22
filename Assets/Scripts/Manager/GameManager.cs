using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
[System.Serializable] // esto ahce que este script pueda ser serializable para asi guardarlo en un archivo

public class GameManager : MonoBehaviour
{
    [Header("Precios comida")]
    [SerializeField]// aqui se indican los precios de la comida que se colocan desde motor
    int zumos,comidas,pagoMes;

    public int dineroDia;
    public int dinMidDia;

    string primerRestaurante = "MainRestaurant";
    public GameData data;

    public GameData gameData;

    public bool findemo = false;


    void Start()
    {
        //esto es para que en los cambios de escena no se destruya el game object y se mantengan las variables
        DontDestroyOnLoad(this.gameObject);
    }
    //se crea un nuevo juego poniendo todas las variables de dinero y dias a sus valores iniciales
    public void NewGame()
    {
        findemo = false;
        gameData.dineroPJ = 0;
        gameData.dia = 1;
        gameData.semana = 1;
        SceneManager.LoadScene(primerRestaurante);
    }
    //se termina el dia y se suma uno mas a la variable de dia
    public void CambioDia()
    {
        gameData.dia++;
        if(gameData.dia>6)
        {
            findemo = true;
            gameData.semana++;
            gameData.dia = 1;
            gameData.dineroPJ -= pagoMes;
        }
        SceneManager.LoadScene("ResumeMenu");
    }
    //se suma el dinero correspondiente a el dinero total (dineroPJ) y al dinerodia si el pedido es 1 se suma
    //el precio del zumo si es otro se suma el dinero de la comida
    public void Pagar(int pedido)
    {
        if(pedido == 1)
        {
            dineroDia += zumos;
            gameData.dineroPJ += zumos;
        }
        if(pedido == 2 || pedido == 3 || pedido == 4 || pedido == 5)
        {
            dineroDia += comidas;
            gameData.dineroPJ += comidas;
        }
    }
    //aqui se guarda la partida esto se ejecuta cada fin de dia
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