using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject saveObject;

    SaveHandler save;

    public GameObject mapCreator;

    public TextMeshProUGUI timeDisplay;

    public GameObject worldMapList;

    public GameObject worldMapPanel;

    public GameObject localMapPanel;

    public TextMeshProUGUI tileTitle;

    public GameObject miniMapPanel;

    public GameObject blockedTile;

    public Sprite tileSprite;

    public Sprite keeperSprite;

    public GameObject[] navButtons = new GameObject[9];

    public GameObject ExploreActionList;

    public GameObject stateInstance;

    public GameObject tileInstance;

    public GameObject actionInstance;

    public GameObject exploreInstance;

    public GameObject TilePosition;

    public GameObject StatePosition;

    public Color[] tileColours = new Color[16];

    /* colour ref
        new Color(1, 0.5f, 0.5f, 1); //fire
        new Color(0.5f, 1, 1, 1), //water
        new Color(0.75f, 0.5f, 0.25f, 1), //earth
        new Color(1, 1, 0.5f, 1), //air
        new Color(0, 0.5f, 0.75f, 1), //arcane
        new Color(0.5f, 1, 0.5f, 1), //plant
        new Color(0.5f, 0.25f, 0.75f, 1), //mystic
        new Color(1, 0.5f, 0.25f, 1), //time
        new Color(0.5f, 0.5f, 0.5f, 1), //ghost
        new Color(1, 0.5f, 1, 0.75), //hallow
        new Color(0.75f, 0.75f, 0.25f, 1), //summoner
        new Color(0.5f, 0.25f, 0.25f, 1), //overseer
        new Color(0.75f, 0.5f, 0.75, 1), //enchant
        new Color(1, 1, 1, 1), //plain
        new Color(0, 0.25f, 0.5f, 1), //ocean
        new Color(0.5f, 0.25f, 0, 1) //mountain
    */
    public Sprite[] stateSprites;

    public Sprite[] tileFeatures;

    public GameObject[] testCurrentTiles = new GameObject[104];

    GameObject[,] currentTiles = new GameObject[13, 8];

    GameObject[] miniMapTiles = new GameObject[9];

    List<Resource> actionsList = new List<Resource>();

    List<NPCClass> npcList = new List<NPCClass>();

    GameObject[] panels;

    StateClass currentState;

    TileClass currentTile;

    int keeperCurrentState;

    public int keeperStateX;

    public int keeperStateY;

    public int keeperTileX;

    public int keeperTileY;

    public int timeNumber;

    bool initialised;

    void Start()
    {
        Initialise();
    }

    void Initialise()
    {
        if (initialised == false)
        {
            save = saveObject.GetComponentInChildren<SaveHandler>();
            keeperStateX = save._GameData.keeper.stateX;
            keeperStateY = save._GameData.keeper.stateY;
            keeperTileX = save._GameData.keeper.tileX;
            keeperTileY = save._GameData.keeper.tileY;
            initialised = true;
        }
    }

    public void MapMade(
        int tileX,
        int tileY,
        int stateX,
        int stateY,
        StateClass state
    )
    {
        EventTracker
            .NewEvent(0,
            "You have discovered a giant egg in your home nation of " +
            state.stateName);
        keeperTileX = tileX;
        keeperTileY = tileY;
        keeperStateX = stateX;
        keeperStateY = stateY;
        currentState = state;
        save.KeeperLocationUpdate (tileX, tileY, stateX, stateY);
        save.SaveFile();
        foreach (TileClass tile in state.tiles)
        {
            if (tile.x == keeperTileX && tile.y == keeperTileY)
                currentTile = tile;
        }
        LoadUI();
    }

    public void Reset()
    {
        foreach (Transform child in worldMapList.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in worldMapPanel.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in localMapPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void CloseMenus()
    {
        panels = GameObject.FindGameObjectsWithTag("MainPanel");
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }

    public void LoadUI()
    {
        keeperStateX = save._GameData.keeper.stateX;
        keeperStateY = save._GameData.keeper.stateY;
        keeperTileX = save._GameData.keeper.tileX;
        keeperTileY = save._GameData.keeper.tileY;
        foreach (StateClass state in save._GameData.stateCoords)
        {
            if (keeperStateX == state.x && keeperStateY == state.y)
            {
                foreach (TileClass tile in state.tiles)
                {
                    if (keeperTileX == tile.x && keeperTileY == tile.y)
                        currentTile = tile;
                }
                currentState = state;
            }
        }
        WorldMapUI();
        LocalMapUI(currentState.tiles);
        MiniMapUI();
    }

    public void ExploreButton()
    {
        MiniMapUI();
    }

    void WorldMapUI()
    {
        foreach (StateClass state in save._GameData.stateCoords)
        {
            GameObject statePrefab =
                Instantiate(stateInstance, worldMapList.transform);
            StateScript prefabScript =
                statePrefab.GetComponentInChildren<StateScript>();
            StateClass createState = state;
            if (state.x == keeperStateX && state.y == keeperStateY)
            {
                currentState = state;
                StatePosition = statePrefab;
            }
            Sprite tempSprite = stateSprites[state.type];
            prefabScript.StateCreate (createState, worldMapPanel, tempSprite);
            statePrefab.SetActive(prefabScript.state.discovered);
        }
    }

    void LocalMapUI(TileClass[] tiles)
    {
        int index = 0;
        foreach (TileClass tile in tiles)
        {
            GameObject tilePrefab =
                Instantiate(tileInstance, localMapPanel.transform);
            Sprite tempSprite = tileSprite;
            TileScript tileScript =
                tilePrefab.GetComponentInChildren<TileScript>();
            if (tile.x == keeperTileX && tile.y == keeperTileY)
            {
                TilePosition = tilePrefab;
                tempSprite = keeperSprite;
            }
            int featureSelect = 0;
            featureSelect = tile.features[0].type;
            Sprite featureSprite1 = tileFeatures[featureSelect];
            featureSelect = tile.features[1].type;
            Sprite featureSprite2 = tileFeatures[featureSelect];
            featureSelect = tile.features[2].type;
            Sprite featureSprite3 = tileFeatures[featureSelect];
            featureSelect = tile.features[3].type;
            Sprite featureSprite4 = tileFeatures[featureSelect];

            tileScript.TileCreate (
                tile,
                tempSprite,
                featureSprite1,
                featureSprite2,
                featureSprite3,
                featureSprite4
            );
            UpdateCurrentTiles(tilePrefab,
            tileScript.tile.x,
            tileScript.tile.y,
            index);
            index++;
        }
    }

    void UpdateCurrentTiles(GameObject tile, int x, int y, int index)
    {
        testCurrentTiles[index] = tile;
        currentTiles[x, y] = tile;
    }

    public void MiniMapUI()
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
                    currentTile =
                        currentTiles[k, j]
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
        ActionList (currentTile);
    }

    void ActionList(TileClass tile)
    {
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

            script.ExploreAction(tile.locationName, tile);
        }

        foreach (FeatureClass feature in tile.features)
        {
            if (feature.occupants.Count != 0 && feature.discovered == true)
                npcList.Add(feature.occupants[0]);
            if (feature.resources.Count != 0 && feature.discovered == true)
                actionsList.Add(feature.resources[0]);
        }
        foreach (NPCClass npc in npcList)
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
                true);
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
            Debug.Log (outOutput);
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
                ActionChecker(resource.duration,
                resource.staminaCost,
                resource.tool,
                resource.skill,
                resource.time,
                resource.requires));
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

        if (save._GameData.keeper.stamina - stamina < 0)
        {
            allowed = false;
        }
        if (!save._GameData.keeper.skills.Contains(skill))
        {
            allowed = false;
        }

        //if (!save._GameData.keeper.tools.Contains(tool)) // check for number of charges
        //{
        //    allowed = false;
        //}
        return allowed;
    }

    void UpdateTime()
    {
        if ((timeNumber > 4 && timeNumber < 7) || (timeNumber > 18 && timeNumber < 20))
        {
            timeDisplay.text = "Twilight";
        }
        else if (timeNumber > 6 && timeNumber < 18)
        {
            timeDisplay.text = "Day";
        }
        else
        {
            timeDisplay.text = "Night";
        }
    }

    public void UpdateKeeperLocationX(int x)
    {
        if (keeperTileX + x <= 12 && keeperTileX + x >= 0)
        {
            keeperTileX += x;
        }
    }

    public void UpdateKeeperLocationY(int y)
    {
        if (keeperTileY + y <= 7 && keeperTileY + y >= 0)
        {
            keeperTileY += y;
        }
    }

    void updateLocalMap()
    {
        foreach (GameObject tile in currentTiles)
        {
            TileScript script = tile.GetComponentInChildren<TileScript>();
            if (script.tile.x == keeperTileX && script.tile.y == keeperTileY)
            {
                script.UpdateTile (keeperSprite);
            }
            else
                script.UpdateTile(tileSprite);
        }
    }
}
