using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    private int playerMoney;

    [SerializeField] private TextMeshProUGUI enemyBaseLifeText;
    private int enemyBaseLife;

    [SerializeField] private TextMeshProUGUI baseLifeText;
    private int baseLife;

    [Header("Result Panel")]
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TextMeshProUGUI resultText;

    private void Awake()
    {
        resultPanel.SetActive(false);
    }

    private void Update()
    {
        playerMoney = GameManager.Instance.GetPlayerCurrency();
        moneyText.text = playerMoney.ToString() + "$";
        enemyBaseLifeText.text = "EnemyBase:" + enemyBaseLife.ToString();
        baseLifeText.text = "Base:" + baseLife.ToString();
    }

    public void UpdateBaseLife(int life)
    {
        baseLife = life;
    }

    public void UpdateEnemyBaseLife(int life)
    {
        enemyBaseLife = life;
    }

    public void ActiveResult(string result)
    {
        resultPanel.SetActive(true);
        resultText.text = result;
    }
}
