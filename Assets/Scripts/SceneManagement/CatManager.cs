using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CatManager : Singleton<CatManager>
{
    [SerializeField] public CatSO[] cats;
    private void Start()
    {
        foreach (var cat in cats)
        {
            cat.appliedUpgrades = cat.specificUpgrades.Union(UpgradeManager.Instance.globalUpgrades);
        }
    }

    public void UpdateCats()
    {
        for (int i = 0; i < cats.Length; i++)
        {
            // Only do this if the player bought at least one
            if (cats[i].amountBought > 0)
            {
                cats[i].lastUpdateTime += Time.deltaTime;
                if (cats[i].lastUpdateTime >= cats[i].GetUpdateInterval())
                {
                    cats[i].lastUpdateTime = 0;
                    GameManager.Instance.currency += cats[i].CalculateIncome();
                }
            }
        }
    }
}
