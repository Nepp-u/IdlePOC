using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] TextMeshProUGUI currentCurrencyText;

// References to BuildingManager and UpgradeManager
    //public BuildingManager buildingManager;
    //public UpgradeManager upgradeManager;
    
    
    public float currency = 0f;

    
    // List/Array of global upgrades that affect the building
    // List/Array of building specific upgrades
    // Phys representation of building

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentCurrencyText.text = "Moneyz: " + currency;
        CatManager.Instance.UpdateBuildings();
    }

    /*
     * Functions that this game should have:
     * Manual clicking on a button to get income
     * Buying buildings for income
     * buildings generating income
     * Upgrades for manual and passive income
     */

    public void ManualClick()
    {
        // Just gonna have at least 1 ClickerUpgrade to start game 
        currency += UpgradeManager.Instance.upgrades[0].CalculateTotalIncrease();
    }
    
}
