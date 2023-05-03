using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Cat", fileName = "New Cat")]
public class CatSO : ScriptableObject
{

    [SerializeField] private string catName = "Enter Cat Name Here";
    [SerializeField] private int baseIncome = 1;
    [SerializeField] private float updateInterval = 1f;
    [SerializeField] public int amountBought = 0;
    [SerializeField] private int priceToBuy = 1;
    [SerializeField] public Sprite catSprite;

    [SerializeField] public UpgradesSO[] specificUpgrades;
    [Serialize] public IEnumerable<UpgradesSO> appliedUpgrades;
    [SerializeField] public float lastUpdateTime = 0f;
    [SerializeField] private float currentIncomePerTick;

    
    private float additiveTotal;
    private float multiplicativeTotal;
    
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

    public string GetCatName()
    {
        return catName;
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
    amountBought = 1;
    priceToBuy = 1;
    }
}
