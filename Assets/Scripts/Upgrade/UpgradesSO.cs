using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade", fileName = "New Upgrade")]
public class UpgradesSO : ScriptableObject, IEquatable<UpgradesSO>
{
    [SerializeField] private string upgradeName = "Enter Name Of Upgrade Here";
    [SerializeField] int additiveIncrease = 1;
    [SerializeField] float multiplicativeIncrease = 1f;

    [SerializeField] int amountBought = 0;
    [SerializeField] private int priceToBuy = 1;

    private float totalIncrease;
    private float additiveTotal;
    private float multiplicativeTotal;
    
    

    public int GetAdditiveIncrease()
    {
        return additiveIncrease * amountBought;
    }

    public float GetMultiplicativeIncrease()
    {
        // This could be 0 and fck over math, so lets not let it
        return Mathf.Max(multiplicativeIncrease * amountBought, 1);
    }

    public void OnUpgradeBought()
    {
        amountBought++;
        priceToBuy += priceToBuy;
    }

    public int GetAmountBought()
    {
        return amountBought;
    }

    public string GetUpgradeName()
    {
        return upgradeName;
    }
    
    public int GetPrice()
    {
        return priceToBuy;
    }
    public float CalculateTotalIncrease()
    {
        totalIncrease = additiveIncrease * multiplicativeIncrease * amountBought;
        return totalIncrease;
    }

    public void Reset()
    {
        amountBought = 0;
        priceToBuy = 1;
    }

    public bool Equals(UpgradesSO other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return base.Equals(other) && upgradeName == other.upgradeName;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((UpgradesSO)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), upgradeName);
    }
}
