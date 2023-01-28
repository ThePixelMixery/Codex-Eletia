using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI actionButton;

    public TextMeshProUGUI actionDetail;

    public TextMeshProUGUI actionFlavour;

    public Button button;

    public void CreateAction(string button, string results, string flavour, bool skillOrObject)
    {
        this.actionButton.text = button;
        this.actionDetail.text = results;
        this.actionFlavour.text = flavour;
        this.button.interactable = skillOrObject;
    }
}
