using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public List<QuestScript> quests;

    public List<DragonScript> dragons;
    public KeeperScript player;
    public MapKeeper map;

    void Start()
    {
        SaveFile();
        LoadFile();
    }

    public void SaveFile()
    {
        string destination= Path.Combine(Application.persistentDataPath, "save.dat");
        FileStream file;

        if (File.Exists(destination))
            file = File.OpenWrite(destination);
        else
            file = File.Create(destination);

        GameData data = new GameData(quests, dragons, player, map);

// switch to JSON
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize (file, data);
        file.Close();
        Debug.Log("Saved to: " + destination);
    }

    public void LoadFile()
    {
        string destination= Path.Combine(Application.persistentDataPath, "save.dat");
        FileStream file;

        if (File.Exists(destination))
            file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }
        //switch to JSON
        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData) bf.Deserialize(file);
        file.Close();

        quests = data.quests;
        dragons = data.dragons;
        player = data.player;
        map = data.map;

        Debug.Log(data.quests);
        Debug.Log(data.dragons);
        Debug.Log(data.player);
        Debug.Log(data.map);
    }
}
