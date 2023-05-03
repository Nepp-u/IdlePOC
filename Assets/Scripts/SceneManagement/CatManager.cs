using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CatManager : Singleton<CatManager>
{
    //private GameManager gameManager;
    [SerializeField] public CatSO[] buildings;


    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        foreach (var building in buildings)
        {
            building.appliedUpgrades = building.specificUpgrades.Union(UpgradeManager.Instance.globalUpgrades);
        }
    }

    public void UpdateBuildings()
    {
        for (int i = 0; i < buildings.Length; i++)
        {
            // Only do this if the player bought at least one
            if (buildings[i].amountBought > 0)
            {
                buildings[i].lastUpdateTime += Time.deltaTime;
                if (buildings[i].lastUpdateTime >= buildings[i].GetUpdateInterval())
                {
                    buildings[i].lastUpdateTime = 0;
                    GameManager.Instance.currency += buildings[i].CalculateIncome();
                }
            }
        }
    }
}
