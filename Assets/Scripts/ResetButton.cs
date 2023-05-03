using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public void OnResetPressed()
    {
        foreach (var building in CatManager.Instance.cats)
        {
            building.Reset();
        }

        foreach (var upgrade in UpgradeManager.Instance.upgrades)
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
