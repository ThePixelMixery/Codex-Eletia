using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    public GameObject saveObject;

    SaveHandler save;

    public GameObject minimapObject;

    MiniMapper minimap;

    public TextMeshProUGUI timeText;

    bool clock;

    public int time;

    public int timeOfDay;

    void Start()
    {
        save = saveObject.GetComponentInChildren<SaveHandler>();
    }

    void displayTime()
    {
        switch (time)
        {
            case 0:
                timeText.text = "Day";
                break;
            case 1:
                timeText.text = "Twilight";
                break;
            case 2:
                timeText.text = "Night";
                break;
            default:
                break;
        }
    }

    public void LoadTime()
    {
        time = save._GameData.keeper.time;
    }

    public int TimeCheck()
    {
        if ((time > 3 && time < 7) || (time > 17 && time < 20))
            timeOfDay = 1;
        else if (time >= 7 && time <= 17)
            timeOfDay = 0;
        else
            timeOfDay = 2;
        return timeOfDay;
    }

    public void ProgressTime(int duration)
    {
    }
}
