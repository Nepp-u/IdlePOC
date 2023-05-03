using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private UpgradesSO upgradeData;
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI footerText;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        UpdateText();
    }

    
    public void OnBuyUpgrade()
    {
        if (upgradeData.GetPrice() < gameManager.currency)
        {
            gameManager.currency -= upgradeData.GetPrice();
            upgradeData.OnUpgradeBought();
            UpdateText();
        }
    }

    private void UpdateText()
    {
        headerText.text = upgradeData.GetUpgradeName();
        footerText.text = "Cost: " + upgradeData.GetPrice();
    }
}
