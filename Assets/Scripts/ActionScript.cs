using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI actionText;
    public TextMeshProUGUI actionDetail;
    public TextMeshProUGUI actionFlavour;

    public string actionTextString;
    public string actionDetailString;
    public string actionFlavourString;


    public void UpdateStrings()
    {
        this.actionText.text=actionTextString;
        this.actionDetail.text=actionDetailString;
        this.actionFlavour.text=actionFlavourString;
    }
}
