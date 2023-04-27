using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Buildings : MonoBehaviour
{
    [SerializeField] private BuildingsSO buildingData;
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI footerText;
    [SerializeField] private Slider tickProgressSlider;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        UpdateText();
    }

    private void Update()
    {
        UpdateSliderProgress();
    }

    private void UpdateText()
    {
        headerText.text = "Buy " + buildingData.GetBuildingName();
        footerText.text = "Cost: " + buildingData.GetPrice();
    }

    public void OnBuildingBought()
    {
        if (buildingData.GetPrice() < gameManager.currency)
        {
            gameManager.currency -= buildingData.GetPrice();
            buildingData.OnUpgradeBought();
            UpdateText();
        }
    }
    
    public void UpdateSliderProgress()
    {
        tickProgressSlider.value = buildingData.lastUpdateTime / buildingData.GetUpdateInterval();
    }
    
}
