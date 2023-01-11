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

    public void SmallMapCreator()
    {
        //for (int i = 0; i < 20; i++)
        //{
        StateClass state = new StateClass("newName", "spec", "cap");
        states.Add (state);
        Debug.Log(state.tiles[0].X);
        //}
        SaveObject.GetComponentInChildren<SaveManager>()._MapData.statesList =
            states;
    }
}
