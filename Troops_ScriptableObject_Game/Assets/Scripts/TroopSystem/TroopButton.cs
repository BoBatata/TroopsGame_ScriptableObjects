using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TroopButton : MonoBehaviour
{
    [SerializeField] private Image troopImage;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Button buyButton;
    private int playerMoney;
    private Troop storedTroop;

    private void Awake()
    {
        buyButton.onClick.AddListener(InvokeOnBuyTroop);
    }

    private void Update()
    {
        playerMoney = GameManager.Instance.GetPlayerCurrency();
    }

    private void InvokeOnBuyTroop()
    {
        if (playerMoney < storedTroop.price)
        {
            print("SemDinheiroBro");
        }
        else
        {
            GameManager.Instance.LoseMoney(storedTroop.price);
            TroopManager.instance.SpawnTroop(storedTroop);
        }
    }

    public void PopulateDisplay(Troop troopToDisplay)
    {
        troopImage.sprite = troopToDisplay.troopSprite;
        priceText.text = troopToDisplay.price.ToString();
        this.storedTroop = troopToDisplay;
    }

    public Troop GetTroop()
    {
        return storedTroop;
    }
}
