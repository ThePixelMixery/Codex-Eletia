using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    DragonClass dragon;

    public TextMeshProUGUI nameFancy;

    public TextMeshProUGUI ageFancy;

    public TextMeshProUGUI bondFancy;

    public TextMeshProUGUI actFancy;

    void Start()
    {
        ageFancy.text = dragon.dragonName;
    }

    // Life Stage updater
    void Update()
    {
        if (
            dragon.age == 1 ||
            dragon.age == 5 ||
            dragon.age == 25 ||
            dragon.age == 100 ||
            dragon.age == 200 ||
            dragon.age == 400 ||
            dragon.age == 750 ||
            dragon.age == 1500 ||
            dragon.age == 3000
        )
        {
            NextAgeStage();
        }
    }

    public void NextAgeStage()
    {
        dragon.age += 0.01f;
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
