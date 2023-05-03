using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : Singleton<UpgradeManager>
{
    // Upgrades that are specific to a building
    [SerializeField] public UpgradesSO[] upgrades;

    // Upgrades that are applied globally to all buildings
    [SerializeField] public UpgradesSO[] globalUpgrades;
    
}
