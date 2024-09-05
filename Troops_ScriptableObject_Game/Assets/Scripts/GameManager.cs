using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputManager InputManager { get; private set; }

    [Header("Managers")]
    public UIManager uiManager;

    [Header("Gameplay Varibles")]
    [SerializeField] private int playerCurrency;

    [SerializeField] private int moneyAddTimeToTime;
    [SerializeField] private float moneyCooldown;
    private float elapsedTime;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnEnemyPoint;
    [SerializeField] private float spawnCoolDown;
    private float elapsedTimeToSpawn;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        InputManager = new InputManager();
        InputManager.EnableCamInputs();
    }

    private void Update()
    {
        MoneyAddTime();
        SpawnEnemy();
    }

    public void WinMoney(int moneyToWin)
    {
        playerCurrency += moneyToWin;
    }
    public void LoseMoney(int moneyToLose)
    {
        playerCurrency -= moneyToLose;
    }

    public int GetPlayerCurrency()
    {
        return playerCurrency;
    }

    private void MoneyAddTime()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= moneyCooldown)
        {
            WinMoney(moneyAddTimeToTime);
            elapsedTime = 0;
        }
    }

    private void SpawnEnemy()
    {
        elapsedTimeToSpawn += Time.deltaTime;

        if (elapsedTimeToSpawn >= spawnCoolDown)
        {
            Instantiate(enemyPrefab, spawnEnemyPoint);
            elapsedTimeToSpawn = 0;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void WinCheck(int enemyLife)
    {
       if (enemyLife <= 0)
       {
            uiManager.ActiveResult("Win");
       }
    }

    public void LoseCheck(int baseLife)
    {
        if (baseLife <= 0)
        {
            uiManager.ActiveResult("Lose");
        }
    }

}
