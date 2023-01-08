using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestClass
{
    public string uniqueID;

    public string questName;

    public GameObject questTitle;

    public string questFlavour;

    public GameObject questDetails;

//    [SerializeField]
    public float questTimeLimit;

    public GameObject questTime;

    public List<string> questRequirements;

    public List<string> questRewards;

    enum questType
    {
        kill,
        gather,
        deliver,
        find,
        explore
    }

    enum questScope
    {
        story,
        state,
        town,
        dragons,
        other
    }

//    [SerializeField]
    enum questState
    {
        known,
        active,
        failed,
        succeeded
    }
}
