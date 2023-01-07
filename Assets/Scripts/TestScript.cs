using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public GameObject testerObject;

    public void testMethod()

    {
    Debug.Log(testerObject.GetComponent<TileScript>().ExploredAmount());
    testerObject.GetComponent<TileScript>().ExploredMore(20);
    Debug.Log(testerObject.GetComponent<TileScript>().ExploredAmount());

    }
}
