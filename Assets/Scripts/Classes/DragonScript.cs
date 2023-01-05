using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float age = 0;
    public float bond;

    public string dragonName;
    public string act;
    
    public TextMeshProUGUI nameFancy;
    public TextMeshProUGUI ageFancy;
    public TextMeshProUGUI bondFancy;
    public TextMeshProUGUI actFancy;


    private enum ageStage{
    Hatchling,
    Wyrmling,
    Juvenile,
    Adult,
    Elder,
    Ancient,
    Wyrm,
    Greatwyrm,
    Death
    };

    void Start(){
    ageFancy.text=dragonName;
    }

    // Life Stage updater
    void Update(){
        if (age == 1 || age == 5 || age == 25 || age == 100 || age == 200 || age == 400 || age == 750 || age == 1500 || age == 3000)
        {
        NextAgeStage();
        }
    }
    
    public void NextAgeStage()
    {

        age += 0.01f; 
/*
    switch(ageStage)
    {
        case Egg:
            ageText.text="Egg";
            health = 1.0f;
            damage = 0.1f;
    }
*/
    }
}
