using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    public static List<GameManager> savedGames = new List<GameManager>();
    GameData data;

    public static void Save()
    {
        data = new GameData();
        data.dia = GameManager.current.gameData.dia;
        savedGames.Add(GameManager.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, data);
        bf.Serialize(file, savedGames);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            savedGames = (List<GameManager>)bf.Deserialize(file);
            data = (GameData)bf.Deserialize(file);
            GameManager.current.gameData = data;
            file.Close();
        }
    }
}
