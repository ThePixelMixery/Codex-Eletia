using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public Button testButton;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void testMethod()
    {
    EventTracker.NewEvent(0,"test Story2");
    EventTracker.NewEvent(1,"test Unlock");
    EventTracker.NewEvent(2,"test Combat");
    EventTracker.NewEvent(3,"test Loot");
//    Debug.Log();
    }
}
