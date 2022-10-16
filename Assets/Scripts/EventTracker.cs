using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventTracker : MonoBehaviour
{
    public class Log
    {
        public int Type;

        public string Content;

        public Log(int type, string content)
        {
            this.Type = type;
            this.Content = content;
        }
    }

    public static Toggle story;

    public static Toggle unlock;

    public static Toggle combat;

    public static Toggle loot;

    public static TextMeshProUGUI logOutput;

    private static List<Log> logs = new List<Log>();

    private static bool Initialised = false;

    public static void initialise()
    {
        if (Initialised == false)
        {
            Initialised = true;
            logOutput =
                GameObject.Find("Text_Log").GetComponent<TextMeshProUGUI>();
            Debug.Log(logOutput + " found");
            story =
                GameObject.Find("Toggle_Story").GetComponent<Toggle>();
            Debug.Log(story + " found");
            unlock =
                GameObject.Find("Toggle_Unlock").GetComponent<Toggle>();
            Debug.Log(unlock + " found");
            combat =
                GameObject.Find("Toggle_Combat").GetComponent<Toggle>();
            Debug.Log(combat + " found");
            loot =
                GameObject.Find("Toggle_Loot").GetComponent<Toggle>();
            Debug.Log(loot + " found");


        }
    }

    void Start()
    {
        initialise();
    }

    public static void NewEvent(int type, string content)
    {
        Log log = new Log(type, content);
        Debug.Log(log.Content);
        logs.Insert(0, log);
        updateEvents();
    }

    public static void updateEvents()
    {
//        if (unlock != null){
//        Debug.Log("Unlock Status = " + unlock.isOn);
//        }
//        else{Debug.Log(unlock);}
        string output = "";
        string entryOutput = "";
        foreach (Log entry in logs)
        {
//            Debug.Log("Entry content = " + entry.Content);
            Debug.Log("Entry Type = " + entry.Type);

            switch (entry.Type)
            {
                case 0:
                    if (story.isOn == true)
                    {
                        entryOutput = "Story = " + entry.Content + "\n -+-*-+- \n";
//                        Debug.Log("Story = " + entryOutput);
                    }
                    break;
                case 1:
                    if (unlock.isOn == true)
                    {
                        entryOutput = "Unlocked = " + entry.Content+ "\n -+-*-+- \n";
//                        Debug.Log("Unlocked = " + entryOutput);
                    }
                    break;
                case 2:
                    if (combat.isOn == true)
                    {
                        entryOutput = "Combat = " + entry.Content+ "\n -+-*-+- \n";
//                        Debug.Log("Combat = " + entryOutput);
                    }
                    break;
                case 3:
                    if (loot.isOn == true)
                    {
                        entryOutput = "Loot = " + entry.Content+ "\n -+-*-+- \n";
//                        Debug.Log("Loot = " + entryOutput);
                    }
                    break;
                default:
                    break;
            }
            output += entryOutput;
        }
        logOutput.text = output;
    }
}
