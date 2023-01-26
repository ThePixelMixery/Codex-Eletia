using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeatureScript : MonoBehaviour
{
    FeatureClass feature;

    //ActionList
    public GameObject actionPrefab;
    public Button activate;
    public TextMeshProUGUI actionButton;
    public TextMeshProUGUI actionDetail;
    public TextMeshProUGUI flavourText;

    //Feature
    public void Discovery()
    {
    feature.discovered=true;
    }
}