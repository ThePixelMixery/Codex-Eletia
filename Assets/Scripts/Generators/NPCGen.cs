using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGen
{
    public static string NPCName;

    public static NPCClass NPC()
    {
    //names
    string generatedName = "NPC";

    NPCClass generatedNPC = new NPCClass();
    generatedNPC.npcName = generatedName; 
    
    return generatedNPC;
    }
}
