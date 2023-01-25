using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StateScript : MonoBehaviour
{
    public int explored;
    public int exploredOutput;
    public int influence;
    public StateClass state;
    public string stateType;

    //Save
    string stateSaveLocation;

    //ListObject
    public TextMeshProUGUI stateTitle;
    public GameObject details;
    public TextMeshProUGUI stateDetails;
    public Sprite open;
    public Sprite closed;
    public Image expand;

    //MapObject
    GameObject worldMapPanel;
    GameObject stateTileObject;
    public GameObject stateTile;

    public void StateCreate(
        StateClass tempState,
        GameObject stateImagePanel,
        Sprite tempSprite
    )
    {
        state = tempState;
        stateTitle.text = state.stateName;
        worldMapPanel = stateImagePanel;
        stateTileObject = Instantiate(stateTile, worldMapPanel.transform);
        stateTileObject.GetComponent<Image>().sprite = tempSprite;
        stateTileObject.SetActive(state.discovered);
    }

    public void UpdateState(bool current)
    {
        if (current) stateTileObject.GetComponent<Image>().color = new Color(0.3f,0.55f,1.0f,1.0f);
        else stateTileObject.GetComponent<Image>().color = Color.white;
        stateTileObject.SetActive(state.discovered);
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
