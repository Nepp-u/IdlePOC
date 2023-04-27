using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    private BuildingManager buildingManager;
    private UpgradeManager upgradeManager;
    private void Awake()
    {
        buildingManager = FindObjectOfType<BuildingManager>();
        upgradeManager = FindObjectOfType<UpgradeManager>();
    }

    public void OnResetPressed()
    {
        foreach (var building in buildingManager.buildings)
        {
            building.Reset();
        }

        foreach (var upgrade in upgradeManager.upgrades)
        {
            upgrade.Reset();
            
            // cba to do it smarter
            if (upgrade.GetUpgradeName() == "Upgrade Clicker")
            {
                upgrade.OnUpgradeBought();
            }
        }
    }
}
