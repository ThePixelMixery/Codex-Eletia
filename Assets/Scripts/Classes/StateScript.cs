using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StateScript : MonoBehaviour
{
    public StateClass state;

    public string stateSaveLocation;

    public TextMeshProUGUI stateTitle;

    public GameObject details;

    public TextMeshProUGUI stateDetails;

    public string stateSpec;

    public int explored;

    public int exploredOutput;

    public int influence;

    public Sprite open;

    public Sprite closed;

    public Image expand;

    public string SpecFancy(int spec)
    {
        string type;
        switch (spec)
        {
            case 0:
                type = "Fire";
                break;
            case 1:
                type = "Water";
                break;
            case 2:
                type = "Earth";
                break;
            case 3:
                type = "Air";
                break;
            case 4:
                type = "Arcane";
                break;
            case 5:
                type = "Mystic";
                break;
            case 6:
                type = "Time";
                break;
            case 7:
                type = "Ghost";
                break;
            case 8:
                type = "Hallow";
                break;
            case 9:
                type = "Summoner";
                break;
            case 10:
                type = "Alchemy";
                break;
            case 11:
                type = "Overseer";
                break;
            case 12:
                type = "Channel";
                break;
            case 13:
                type = "Immoral";
                break;
            case 14:
                type = "Ocean";
                break;
            case 15:
                type = "Divide";
                break;
            default:
                type = "Invalid State Spec/Unassigned";
                Debug.LogError (type);
                break;
        }
        return type;
        //        UpdateDetails(type);
    }

    /*    
    public void UpdateDetails(string spec)
    {
        stateDetails.text =
            state.specialisation +
            "\n" +
            state.influence +
            "\n" +
            state.capital +
            "\n" +
            state.exploredOutput +
            "%";
    }
*/
    /*
    public void UpdateInf(int inf)
    {
        state.influence += inf;
        UpdateDetails();
        Debug.Log("Influence Updated");
    }

    public void UpdateExp(int explore)
    {
        state.explored += explore;
        state.exploredOutput = state.explored / 9200;
        UpdateDetails();
        Debug.Log("Explore Updated");
    }
    */
    //opens and closes detail menu
    public void AccordionDetails()
    {
        if (details.activeSelf == false)
        {
            expand.sprite = open;
            details.SetActive(true);
        }
        else
        {
            expand.sprite = closed;
            details.SetActive(false);
        }
    }
}
