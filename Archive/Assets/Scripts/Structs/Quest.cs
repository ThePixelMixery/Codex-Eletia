using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Quest
{
    public string uniqueID;

    public string questName;

    public GameObject questTitle;

    public string questFlavour;

    public GameObject questDetails;

    public float questTimeLimit;

    public GameObject questTime;

    public List<string> questRequirements;

    public List<string> questRewards;

    int questType;
        /*
        kill,
        gather,
        deliver,
        find,
        explore
        */

    int questScope;
        /*
        story,
        state,
        town,
        dragons,
        other
        */

    int questState;
        /*
        known,
        active,
        failed,
        succeeded
        */
    
}
