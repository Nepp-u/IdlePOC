using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] public BuildingsSO[] buildings;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        foreach (var building in buildings)
        {
            building.appliedUpgrades = building.specificUpgrades.Union(gameManager.upgradeManager.globalUpgrades);
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
                    gameManager.currency += buildings[i].CalculateIncome();
                }
            }
        }
    }
}
