using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapper : MonoBehaviour
{
    public GameObject saveObject;

    SaveHandler save;

    Keeper keeper;

    public GameObject clockObject;

    TimeScript clock;

    public GameObject miniMapPanel;

    public GameObject blockedTile;

    public Sprite tileSprite;

    public Sprite keeperSprite;

    public TextMeshProUGUI tileTitle;

    public GameObject ExploreActionList;

    public GameObject actionInstance;

    public GameObject exploreInstance;

    GameObject[] miniMapTiles = new GameObject[9];

    List<Resource> actionsList = new List<Resource>();

    List<NPC> npcList = new List<NPC>();

    GameObject tileObject;

    public GameObject[] navButtons = new GameObject[9];

    void Start()
    {
        save = saveObject.GetComponentInChildren<SaveHandler>();
        keeper = save._GameData.keeper;
        clock = clockObject.GetComponentInChildren<TimeScript>();
    }

    public void MiniMapUI(
        int keeperTileX,
        int keeperTileY,
        GameObject[,] currentTiles,
        Tile currentTile
    )
    {
        foreach (Transform child in miniMapPanel.transform)
        Destroy(child.gameObject);
        Array.Clear(miniMapTiles, 0, 9);

        for (int j = 0; j < 8; j++)
        {
            for (int k = 0; k < 13; k++)
            {
                if (keeperTileX - 1 == k && keeperTileY - 1 == j)
                {
                    miniMapTiles[0] = currentTiles[k, j];
                }
                else if (keeperTileX == k && keeperTileY - 1 == j)
                {
                    miniMapTiles[1] = currentTiles[k, j];
                }
                else if (keeperTileX + 1 == k && keeperTileY - 1 == j)
                {
                    miniMapTiles[2] = currentTiles[k, j];
                }
                else if (keeperTileX - 1 == k && keeperTileY == j)
                {
                    miniMapTiles[3] = currentTiles[k, j];
                }
                else if (keeperTileX == k && keeperTileY == j)
                {
                    miniMapTiles[4] = currentTiles[k, j];
                    tileObject = currentTiles[k, j];
                    currentTile =
                        tileObject
                            .GetComponentInChildren<TileScript>()
                            .tile;
                }
                else if (keeperTileX + 1 == k && keeperTileY == j)
                {
                    miniMapTiles[5] = currentTiles[k, j];
                }
                else if (keeperTileX - 1 == k && keeperTileY + 1 == j)
                {
                    miniMapTiles[6] = currentTiles[k, j];
                }
                else if (keeperTileX == k && keeperTileY + 1 == j)
                {
                    miniMapTiles[7] = currentTiles[k, j];
                }
                else if (keeperTileX + 1 == k && keeperTileY + 1 == j)
                {
                    miniMapTiles[8] = currentTiles[k, j];
                }
            }
        }

        for (int i = 0; i < 9; i++)
        {
            int illegalTile = 0;
            if (miniMapTiles[i] != null)
            {
                navButtons[i].GetComponentInChildren<Button>().interactable =
                    true;

                illegalTile =
                    miniMapTiles[i]
                        .GetComponentInChildren<TileScript>()
                        .tile
                        .type;

                miniMapTiles[i]
                    .GetComponentInChildren<TileScript>()
                    .Discovery();
                if (i == 4)
                {
                    miniMapTiles[i]
                        .GetComponentInChildren<TileScript>()
                        .UpdateTile(keeperSprite);
                }
                else
                {
                    miniMapTiles[i]
                        .GetComponentInChildren<TileScript>()
                        .UpdateTile(tileSprite);
                }
                Instantiate(miniMapTiles[i], miniMapPanel.transform);
            }
            else
            {
                navButtons[i].GetComponentInChildren<Button>().interactable =
                    false;
                Instantiate(blockedTile, miniMapPanel.transform);
            }

            if (illegalTile == 15 || illegalTile == 14)
                navButtons[i].GetComponentInChildren<Button>().interactable =
                    false;
        }

        tileTitle.text = currentTile.locationName;
        ActionList (tileObject);
    }

    void ActionList(GameObject tileObject)
    {
        Tile tile = tileObject.GetComponentInChildren<TileScript>().tile;
        foreach (Transform child in ExploreActionList.transform)
        Destroy(child.gameObject);

        actionsList.Clear();
        npcList.Clear();

        if (tile.explored < 100)
        {
            GameObject actionPrefab =
                Instantiate(exploreInstance, ExploreActionList.transform);
            ActionScript script =
                actionPrefab.GetComponentInChildren<ActionScript>();
            script.ExploreAction(tile.locationName, tileObject);
        }

        foreach (Feature feature in tile.features)
        {
            if (
                feature.occupants != null &&
                feature.occupants.Count != 0 &&
                feature.discovered == true
            ) npcList.Add(feature.occupants[0]);
            if (feature.resources.Count != 0 && feature.discovered == true)
                actionsList.Add(feature.resources[0]);
        }
        foreach (NPC npc in npcList)
        {
            GameObject actionPrefab =
                Instantiate(actionInstance, ExploreActionList.transform);
            ActionScript script =
                actionPrefab.GetComponentInChildren<ActionScript>();
            script
                .ReturnAction("Talk",
                npc.flavourText,
                0,
                "Visit " + npc.npcName + "at the " + npc.homeName,
                0,
                null,
                null,
                0,
                null,
                null,
                null,
                true,
                actionPrefab);
        }

        foreach (Resource resource in actionsList)
        {
            List<string> requirements = new List<string>();
            foreach (require req in resource.requires)
            {
                requirements
                    .Add(req.item.itemName + " (" + req.count.ToString() + ")");
            }
            string reqsOutput = String.Join(", ", requirements.ToArray());
            List<string> results = new List<string>();
            foreach (outcome result in resource.outcomes)
            {
                results
                    .Add(result.min.ToString() +
                    "-" +
                    result.max.ToString() +
                    " " +
                    result.item.itemName +
                    " (" +
                    result.chance.ToString() +
                    "%) ");
            }
            string outOutput = String.Join(", ", results.ToArray());
            GameObject actionPrefab =
                Instantiate(actionInstance, ExploreActionList.transform);
            ActionScript script =
                actionPrefab.GetComponentInChildren<ActionScript>();
            script
                .ReturnAction(resource.action,
                resource.resourceName,
                resource.duration,
                resource.flavourText,
                resource.staminaCost,
                resource.tool,
                resource.skill,
                resource.time,
                reqsOutput,
                outOutput,
                resource.outcomes, //resource.outcomes,
                /*
                ActionChecker(resource.duration,
                resource.staminaCost,
                resource.tool,
                resource.skill,
                resource.time,
                resource.requires),*/ true, actionPrefab);
        }
    }

    bool
    ActionChecker(
        int duration,
        int stamina,
        string tool,
        string skill,
        int time,
        List<require> reqs
    )
    {
        bool allowed = true;
        int currentTime = clock.time;
        int predictedTime = currentTime + duration;
        if (predictedTime >= 24) predictedTime = predictedTime % 24;
        if (time != clock.timeOfDay || time != 3) allowed = false;
        if (keeper.stamina - stamina < 0) allowed = false;
        if (!keeper.skills.Contains(skill)) allowed = false;
        if (clock.timeOfDay != time || time != 3) allowed = false;

        return allowed;
    }
}
