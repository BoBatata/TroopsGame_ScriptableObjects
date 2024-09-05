using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopManager : MonoBehaviour
{
    public static TroopManager instance;

    public Troop[] troops;
    [SerializeField] private GameObject troopPrefab;
    private Troop troopToSpawn;
    [SerializeField] private Transform spawnPoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SpawnTroop(Troop troop)
    {
        troopToSpawn = troop;
        Instantiate(troopPrefab, spawnPoint);
    }

    public Troop GetTroopInformation()
    {
        return troopToSpawn;
    }
}
