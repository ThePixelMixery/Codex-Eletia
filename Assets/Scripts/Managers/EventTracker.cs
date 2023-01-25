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

    static Toggle story;

    static Toggle unlock;

    static Toggle combat;

    static Toggle loot;

    public static TextMeshProUGUI logOutput;

    private static List<Log> logs = new List<Log>();

    private static bool Initialised = false;

    //checks for elements
    public static void initialise()
    {
        if (Initialised == false)
        {
            Initialised = true;
            logOutput =
                GameObject.Find("Text_Log").GetComponent<TextMeshProUGUI>();
            story = GameObject.Find("Toggle_Story").GetComponent<Toggle>();
            unlock = GameObject.Find("Toggle_Unlock").GetComponent<Toggle>();
            combat = GameObject.Find("Toggle_Combat").GetComponent<Toggle>();
            loot = GameObject.Find("Toggle_Loot").GetComponent<Toggle>();
            Debug
                .Log(logOutput +
                "," +
                story +
                " ," +
                unlock +
                " ," +
                combat +
                " ," +
                loot);
        }
    }

    void Start()
    {
        initialise();
    }

    // for external use of creating events
    public static void NewEvent(int type, string content)
    {
        Log log = new Log(type, content);

        //Debug.Log(log.Content);
        logs.Insert(0, log);
        updateEvents();
    }

    // updates event list
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
                    if (story.isOn == true)
                    {
                        entryOutput =
                            "Story: " + entry.Content + "\n -+-*-+- \n";
                        //Debug.Log("Story = " + entryOutput);
                    }
                    else
                    {
                        entryOutput = "";
                    }
                    break;
                case 1:
                    if (unlock.isOn == true)
                    {
                        entryOutput =
                            "Unlocked: " + entry.Content + "\n -+-*-+- \n";
                        //Debug.Log("Unlocked = " + entryOutput);
                    }
                    else
                    {
                        entryOutput = "";
                    }
                    break;
                case 2:
                    if (combat.isOn == true)
                    {
                        entryOutput =
                            "Combat: " + entry.Content + "\n -+-*-+- \n";
                        //Debug.Log("Combat = " + entryOutput);
                    }
                    else
                    {
                        entryOutput = "";
                    }
                    break;
                case 3:
                    if (loot.isOn == true)
                    {
                        entryOutput =
                            "Loot: " + entry.Content + "\n -+-*-+- \n";
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
