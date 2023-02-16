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

    public GameObject tileObject;

    public Button button;

    List<Item> items;

    List<outcome> outcome;

    MapManager maps;

    InventoryManager invo;

    SaveHandler save;

    string resourceName;

    int type;

    int featureId;

    int resourceId;

    GameObject actionObject;

    Resource resource;

    void Start()
    {
        button.onClick.AddListener (ClickAction);
        maps =
            GameObject.Find("GameObject_MapManager").GetComponent<MapManager>();
        invo =
            GameObject
                .Find("GameObject_Inventory")
                .GetComponent<InventoryManager>();
        save = GameObject.Find("GameObject_Save").GetComponent<SaveHandler>();
    }

    public void ExploreAction(string locationName, GameObject tileObject)
    {
        this.actionResource.text = locationName + " for 3 hours";
        this.actionButton.text = "Explore";
        this.actionFlavour.text = "Scout the local area for things to do";
        this.actionStamina.text = "0";
        this.actionDaytime.text = "Day";
        this.type = 0;
        this.tileObject = tileObject;
    }

    public void TalkAction(
        string button,
        string resourceName,
        int duration,
        string flavour,
        GameObject actionObject
    )
    {
        this.resourceName = resourceName;
        this.actionResource.text = resourceName + " for " + duration + " hours";
        this.actionButton.text = button;
        this.actionFlavour.text = flavour;
        this.type = 1;
        this.actionObject = actionObject;
    }

    public void ReturnAction(
        string button,
        string resourceName,
        int duration,
        string flavour,
        int stamina,
        string skill,
        string tool,
        int daytime,
        string details,
        string results,
        List<outcome> outcome,
        bool skillOrObject,
        GameObject actionObject,
        int featureId,
        int resourceId
    )
    {
        this.resourceName = resourceName;
        this.actionResource.text = resourceName + " for " + duration + " hours";
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
        this.outcome = outcome;
        this.button.interactable = skillOrObject;
        this.type = 2;
        this.actionObject = actionObject;
        this.featureId = featureId;
        this.resourceId = resourceId;
    }

    void ClickAction()
    {
        switch (type)
        {
            case 0:
                tileObject
                    .GetComponentInChildren<TileScript>()
                    .FeatureDiscovery(25);
                maps.UpdateCurrentTile (tileObject);
                break;
            case 1:
                Debug.Log("Talked to someone");
                break;
            case 2:
                Debug.Log(outcome[0].chance);
                invo.Sourced (outcome, resourceName);
                tileObject
                    .GetComponentInChildren<TileScript>()
                    .ResourceDisable(featureId, resourceId);
                maps.UpdateCurrentTile (tileObject);
                actionObject.SetActive(false);
                break;
            default:
                break;
        }
        save.SaveFile();
    }
}
