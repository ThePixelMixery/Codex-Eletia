using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public GameObject SaveObject;

    public GameObject LocalMapPanel;

    public int mapSize;

    public List<StateClass> states;

    public void Start()
    {
    }

    public void mapSizer(int size)
    {
        switch (size)
        {
            case 0:
                SmallMapCreator();
                break;
            case 1:
                break;
            case 2:
                break;
            default:
                break;
        }
    }

    // Start is called before the first frame update
    public void SmallMapCreator()
    {
        for (int i = 0; i < 20; i++)
        {
        states.Add(new StateClass("newName", "spec", "cap"));
        }
    SaveObject.GetComponentInChildren<SaveManager>()._MapData.statesList = states;
    }
}
