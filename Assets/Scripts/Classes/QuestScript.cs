using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
	public string uniqueID;
	public string questName;
	public List<string> questRequirements;
	public List<string> questRewards;
	enum questType{kill, gather, deliver, find, explore}
    enum questScop{story, state, town, dragons, other}
	[SerializeField]
	enum questState{known, active, failed, succeeded}
}
