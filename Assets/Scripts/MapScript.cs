using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public class Town
    {
        public string TownName;

        public string State;

        public int DistFromCap;

        public bool Castle;

        public bool TownHall;

        public int Lookouts;

        public int Houses;

        public bool Farrier;

        public bool Church;

        public bool Inn;

        public bool Guild;

        public List<GameObject> Market;

        public List<GameObject> Other;

        public Town(
            string townName,
            string state,
            int distFromCap,
            bool castle,
            bool townHall,
            int lookouts,
            int houses,
            bool farrier,
            bool church,
            bool inn,
            bool guild
        ) //            List<GameObject> other //            List<GameObject> market, //,
        {
            this.TownName = townName;
            this.State = state;
            this.DistFromCap = distFromCap;
            this.Castle = castle;
            this.TownHall = townHall;
            this.Lookouts = lookouts;
            this.Houses = houses;
            this.Farrier = farrier;
            this.Church = church;
            this.Inn = inn;
            this.Guild = guild;
            //            this.Market = market;
            //            this.Other = other;
        }
    }

    public static Town NewTown(
        string TownName,
        string state,
        int distFromCap,
        bool castle,
        bool townHall,
        int lookouts,
        int houses,
        bool farrier,
        bool church,
        bool inn,
        bool guild
    ) //            List<GameObject> other //            List<GameObject> market, //,
    {
        Town town =
            new Town(TownName,
                state,
                distFromCap,
                castle,
                townHall,
                lookouts,
                houses,
                farrier,
                church,
                inn,
                guild); //,

        //                    market,
        //                    other
        Debug
            .Log(town.TownName +
            ", " +
            town.State +
            ", " +
            town.Castle +
            ", " +
            town.TownHall +
            ", " +
            town.Lookouts +
            ", " +
            town.Houses +
            ", " +
            town.Farrier +
            ", " +
            town.Church +
            ", " +
            town.Inn +
            ", " +
            town.Guild +
            ", "); //+
        //                    town.Market+", "+
        //                    town.Other
        return town;
    }

    public class State
    {
        public string StateName;

        public string Specialisation;

        public string Capital;

        public int Towns;

        public List<Town> TownList;

        public State(string stateName, string spec, string cap, int towns)
        {
            this.StateName = stateName;
            this.Specialisation = spec;
            this.Capital = cap;
            this.Towns = towns;
            this.TownList = new List<Town>();
            for (int i = 0; 1 < towns; towns++)
            {
                TownList
                    .Add(NewTown("Juiceville",
                    "Texas",
                    200,
                    true,
                    true,
                    4,
                    14,
                    true,
                    true,
                    true,
                    false));
            }
        }
    }

    public static void NewState(
        string stateName,
        string spec,
        string cap,
        int towns
    ) 
    {
        State state =
            new State(stateName,spec,cap,towns);
            Debug.Log(state.StateName+", "+state.Specialisation+", "+state.Capital+", "+state.Towns);
            foreach (Town location in state.TownList)
            {
            Debug.Log(state.TownList);
            }
    }
}
