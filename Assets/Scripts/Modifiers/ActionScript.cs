using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI actionButton;

    public TextMeshProUGUI actionStamina;

    public TextMeshProUGUI actionTool;

    public TextMeshProUGUI actionSkill;

    public TextMeshProUGUI actionDaytime;

    public TextMeshProUGUI actionResource;

    public TextMeshProUGUI actionFlavour;

    public TextMeshProUGUI actionDetail;

    public TextMeshProUGUI actionReturn;

    public Button button;

    public void CreateAction(
        string button,
        string resource,
        int duration,
        string flavour,
        int stamina,
        string skill,
        string tool,
        int daytime,
        string details,
        string results,
        bool skillOrObject
    )
    {
        this.actionResource.text = resource + " for " + duration + " hours";
        this.actionButton.text = button;
        this.actionFlavour.text = flavour;
        this.actionStamina.text = stamina.ToString();
        this.actionTool.text = tool;
        this.actionSkill.text = skill;
        string timeOfDay;
        switch (daytime)
        {
            case 0:
                timeOfDay = "Day";
                break;
            case 1:
                timeOfDay = "Night";
                break;
            case 2:
                timeOfDay = "Twilight";
                break;
            case 3:
                timeOfDay = "Anytime";
                break;
            default:
                timeOfDay = "Day";
                break;
        }

        this.actionDaytime.text = timeOfDay;
        this.actionDetail.text = details;
        this.actionReturn.text = results;
        this.button.interactable = skillOrObject;
    }

    void Start()
    {
        button.onClick.AddListener (ClickAction);
    }
    void ClickAction()
    {
    
    
    }
}
