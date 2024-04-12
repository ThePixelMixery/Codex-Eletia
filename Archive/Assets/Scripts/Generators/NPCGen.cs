using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGen
{
    public static string NPCName;

    public static NPC NPC()
    {
    //names
    string generatedName = "NPC";

    NPC generatedNPC = new NPC();
    generatedNPC.npcName = generatedName; 
    
    return generatedNPC;
    }
}
