using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportScript : MonoBehaviour
{
    public class Transport
    {
        public string Name;

        public int Speed;

        public int SeatsMin;

        public int SeatsMax;

        public int Storage;

        public bool Enclosed;

        public int MountMin;

        public int MountMax;

        public List<Mount> Yoked;
    }

    public class Mount
    {
        public string Name;

        public int Speed;

        public int Storage;

        public GameObject Attached;
    }
}
