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

    public static Toggle Story;

    public static Toggle Unlock;

    public static Toggle Combat;

    public static Toggle Loot;

    public static TextMeshProUGUI logOutput;

    private static List<Log> logs = new List<Log>();

    private static bool Initialised = false;

    public static void initialise()
    {
        if (Initialised == false)
        {
            Initialised = true;
            logOutput = GameObject.Find("Text_Log").GetComponent<TextMeshProUGUI>();
            Debug.Log(logOutput + " found");
            Story = GameObject.Find("Toggle_Story").GetComponent<Toggle>();
            Debug.Log(Story + " found");
            Unlock = GameObject.Find("Toggle_Unlock").GetComponent<Toggle>();
            Debug.Log(Unlock + " found");
            Combat = GameObject.Find("Toggle_Combat").GetComponent<Toggle>();
            Debug.Log(Combat + " found");
            Loot = GameObject.Find("Toggle_Loot").GetComponent<Toggle>();
            Debug.Log(Loot + " found");
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
        //if (Unlock != null){
        //Debug.Log("Unlock Status = " + Unlock.isOn);
        //}
        //else{Debug.Log(Unlock);}
        string output = "";
        string entryOutput = "";
        foreach (Log entry in logs)
        {
            //Debug.Log("Entry content = " + entry.Content);
            //Debug.Log("Entry Type = " + entry.Type);
            switch (entry.Type)
            {
                case 0:
                    if (Story.isOn == true)
                    {
                        entryOutput =
                            "Story = " + entry.Content + "\n -+-*-+- \n";
                        //Debug.Log("Story = " + entryOutput);
                    }
                    else
                    {
                        entryOutput = "";
                    }
                    break;
                case 1:
                    if (Unlock.isOn == true)
                    {
                        entryOutput =
                            "Unlocked = " + entry.Content + "\n -+-*-+- \n";
                        //Debug.Log("Unlocked = " + entryOutput);
                    }
                    else
                    {
                        entryOutput = "";
                    }
                    break;
                case 2:
                    if (Combat.isOn == true)
                    {
                        entryOutput =
                            "Combat = " + entry.Content + "\n -+-*-+- \n";
                        //Debug.Log("Combat = " + entryOutput);
                    }
                    else
                    {
                        entryOutput = "";
                    }
                    break;
                case 3:
                    if (Loot.isOn == true)
                    {
                        entryOutput =
                            "Loot = " + entry.Content + "\n -+-*-+- \n";
                        //Debug.Log("Loot = " + entryOutput);
                    }
                    else
                    {
                        entryOutput = "";
                    }
                    break;
                default:
                    entryOutput = "";
                    break;
            }
            output += entryOutput;
        }
        logOutput.text = output;
    }
}
