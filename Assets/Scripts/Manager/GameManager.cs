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
    int zumos,comidas;

    public int dineroDia;
    public int dinMidDia;

    string primerRestaurante = "Resttaurante_001Final";
    public GameData data;

    public GameData gameData;

    public bool findemo = false;

    public int pagoMes1, pagoMes2, pagoMes3;


    void Start()
    {
        //esto es para que en los cambios de escena no se destruya el game object y se mantengan las variables
        DontDestroyOnLoad(this.gameObject);
    }
    //se crea un nuevo juego poniendo todas las variables de dinero y dias a sus valores iniciales
    public void NewGame()
    {
        gameData.dineroPJ = 0;
        gameData.dia = 1;
        gameData.semana = 1;
        gameData.bar1 = false;
        gameData.bar2 = false;
        SceneManager.LoadScene(primerRestaurante);
    }
    //se termina el dia y se suma uno mas a la variable de dia

    public void ResetGame ()
    {
        gameData.dineroPJ = 0;
        gameData.dia = 1;
        gameData.semana = 1;
        gameData.bar1 = false;
        gameData.bar2 = false;
        Save();
        SceneManager.LoadScene("MainMenu");
    }
    public void CambioDia()
    { 
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
    //aqui se guarda la partida esto se ejecuta cada fin de dia para esto se ha creado una clase game data con las variables que se quieren
    //guardar despues estas se pasan a codigo bianrio que se guarda en una carpeta que creamos(file.create) se serializa y se cierra el archivo
    public void Save()
    {
        data = new GameData();

        data.dia = gameData.dia;
        data.semana = gameData.semana;
        data.dineroPJ = gameData.dineroPJ;
        data.bar1 = gameData.bar1;
        data.bar2 = gameData.bar2;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, data);
        file.Close();
    }
    //para cargar partida se hace lo mismo que para guardar pero a la inversa, si existe un archivo de gusrdado, se abre
    //y se deseializa para que unity pueda leer las variables, estas se igualan a el game data actual y se carga la escena del restaurante
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
    //con esto se cierra el juego
    public void Salir()
    {
        Application.Quit();
    }
}
    //una clase creada para guardar las variables que se quieran serializar para guardar partida
    [System.Serializable]
    public class GameData
    {
        public int dineroPJ;
        public int dia = 1, semana = 1;
        public bool bar1 = false, bar2 = false;

    }