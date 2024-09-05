using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TroopDisplay : MonoBehaviour
{
    private Troop[] troopsToDisplay;
    private TroopButton selectedButton;
    [SerializeField] private TroopButton troopContainerPrefab;
    [SerializeField] private GameObject gridToSpawn;

    private void Start()
    {
        troopsToDisplay = TroopManager.instance.troops;
        DisplayTroops();
    }

    private void DisplayTroops()
    {
        foreach (Troop troop in troopsToDisplay)
        {
            TroopButton troopBtn = Instantiate(troopContainerPrefab, gridToSpawn.transform);
            troopBtn.PopulateDisplay(troop);
        }
    }
}
