using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Alerter : MonoBehaviour
{
    static GameObject alertPanel;

    static TextMeshProUGUI alertTitle;

    static TextMeshProUGUI alertDetail;

    static GameObject dragonButtons;

    void Start()
    {
        alertPanel = GameObject.Find("Panel_Misc");
        alertTitle =
            GameObject.Find("Text_AlertTitle").GetComponent<TextMeshProUGUI>();
        alertDetail =
            GameObject.Find("Text_AlertDetail").GetComponent<TextMeshProUGUI>();
        dragonButtons = GameObject.Find("GameObject_DragonButtons");
        alertPanel.SetActive(false);
    }

    public static void Alert(string title, string detail)
    {
        alertTitle.text = title;
        alertDetail.text = detail;
        alertPanel.SetActive(true);
    }

    public static void DragonSelect()
    {
        Alert("An unexpected friend",
        "While out playing, you notice something different. A large egg is on the ground, it has a crack running through it. You decide you have to help but it's too large to carry. What do you do?");
        dragonButtons.SetActive(true);
    }

    public static void DragonSelected()
    {
        dragonButtons.SetActive(false);
        alertPanel.SetActive(false);
    }
}
