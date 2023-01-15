using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Civilisation : MonoBehaviour
{


    public bool castle;

    public bool townHall;

    public int lookouts;

    public int houses;

    public bool farrier;

    public bool church;

    public bool inn;

    public bool guild;

    public List<GameObject> market;

    public List<GameObject> other;
/*
    public CivilTile(bool Church)
    {
        this.church = Church;
    }
    
        string location,
        int X,
        int Y,
        int Access,
        int Lookouts,
        int Houses,
        bool Farrier,
        bool Church,
        bool Inn,
        bool Guild

    ) //:base(X, Y)

    {
        this.locationName = location;
        this.x = X;
        this.y = Y;
        this.explored = 0;
        this.access = Access;
        this.castle = false;
        this.townHall = true;
        this.lookouts = Lookouts;
        this.houses = Houses;
        this.farrier = Farrier;
        this.church = Church;
        this.inn = Inn;
        this.guild = Guild;
    }
*/
}
