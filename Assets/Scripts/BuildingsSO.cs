using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Passive Building", fileName = "New Building")]
public class BuildingsSO : ScriptableObject
{

    [SerializeField] private string buildingName = "Enter Building Name Here";
    [SerializeField] private int baseIncome = 1;
    [SerializeField] private float updateInterval = 1f;
    [SerializeField] public int amountBought = 0;
    [SerializeField] private int priceToBuy = 1;
    [SerializeField] private Sprite buildingSprite;

    [FormerlySerializedAs("effectiveUpgrades")] [SerializeField] public UpgradesSO[] specificUpgrades;
    [Serialize] public IEnumerable<UpgradesSO> appliedUpgrades;
    [SerializeField] public float lastUpdateTime = 0f;
    [SerializeField] private float currentIncomePerTick;

    
    private float additiveTotal;
    private float multiplicativeTotal;
    
    
    // TODO: add Sprite for building
    
    public float CalculateIncome()
    {
        // TODO: rethink formula
        // sooooo .... (buildingBase * buildingAmount) + upgradeAdditive * upgradeMult OR (buildingBase + upgradeAdditive) * upgradeMult * buildingAmount 
        CalculateMultipliers();
        currentIncomePerTick = (baseIncome + additiveTotal) * multiplicativeTotal * amountBought;
        return currentIncomePerTick;
    }

    private void CalculateMultipliers()
    {
        additiveTotal = 0;
        multiplicativeTotal = 1;
    
        foreach (var upgrade in appliedUpgrades)
        {
            additiveTotal += upgrade.GetAdditiveIncrease();
            multiplicativeTotal += upgrade.GetMultiplicativeIncrease();
        }
    }

    public string GetBuildingName()
    {
        return buildingName;
    }

    public float GetUpdateInterval()
    {
        return updateInterval;
    }

    public int GetPrice()
    {
        return priceToBuy;
    }

    public void OnUpgradeBought()
    {
        amountBought++;
        priceToBuy *= 2;
    }

    public void Reset()
    {
    amountBought = 0;
    priceToBuy = 1;
    }
}
