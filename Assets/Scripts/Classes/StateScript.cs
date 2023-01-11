using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StateScript : MonoBehaviour
{
    StateClass state;

    public TextMeshProUGUI stateTitle;

    public GameObject details;

    public TextMeshProUGUI stateDetails;

    public Sprite open;

    public Sprite closed;

    public Image expand;


    public void Start()
    {
        stateTitle.text = state.stateName;
        UpdateDetails();
    }

    public void UpdateDetails()
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
