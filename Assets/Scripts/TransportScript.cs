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

        public Transport(
            string name,
            int speed,
            int seatsMin,
            int seatsMax,
            int storage,
            bool enclosed,
            int mountMin,
            int mountMax,
            List<Mount> yoked
        )
        {
            this.Name = name;
            this.Speed = speed;
            this.SeatsMin = seatsMin;
            this.SeatsMax = seatsMax;
            this.Storage = storage;
            this.Enclosed = enclosed;
            this.MountMin = mountMin;
            this.MountMax = mountMax;
            this.Yoked = yoked;
        }
    }

    public class Mount
    {
        public string Name;

        public int Speed;

        public int Storage;

        public GameObject Attached;
    }
}
