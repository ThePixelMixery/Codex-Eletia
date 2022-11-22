using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StateScript : MonoBehaviour
{
    public TextMeshProUGUI stateTitle;

    public Image expand;

    public GameObject details;

    public TextMeshProUGUI stateDetails;

    public Sprite open;

    public Sprite closed;

    public string stateName;

    public string specialisation;

    public string capital;

    //        public List<Town> TownList;
    [SerializeField]
    public int explored;

    public int exploredOutput;

    [SerializeField]
    public int influence;

    public void Start()
    {
        stateTitle.text = stateName;
        UpdateDetails();
    }

    public void UpdateDetails()
    {
        stateDetails.text =
            specialisation +
            "\n" +
            influence +
            "\n" +
            capital +
            "\n" +
            exploredOutput +
            "%";
    }

    public void CreateState(string name, string spec)
    {
        this.stateName = name;
        this.specialisation = spec;
        this.influence = 0;
        this.explored = 0;
        Debug.Log("State created");
    }

    public void UpdateInf(int inf)
    {
        this.influence += inf;
        UpdateDetails();
        Debug.Log("Influence Updated");
    }

    public void UpdateExp(int explore)
    {
        this.explored += explore;
        this.exploredOutput = explored/9200;
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
