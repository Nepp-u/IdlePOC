using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Buildings : MonoBehaviour
{
    [SerializeField] private BuildingsSO buildingData;
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI footerText;
    [SerializeField] private Slider tickProgressSlider;
    [SerializeField] private Button buyButton;
    [SerializeField] private GameObject CatPrefab;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        UpdateText();
        buyButton.image.sprite = buildingData.buildingSprite;
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
            SpawnNewCat();
        }
    }
    
    public void UpdateSliderProgress()
    {
        tickProgressSlider.value = buildingData.lastUpdateTime / buildingData.GetUpdateInterval();
    }

    void SpawnNewCat()
    {
        GameObject newCat = Instantiate(CatPrefab, new Vector3(-2, 0, 0), quaternion.identity);
        newCat.transform.SetParent(FindObjectOfType<BuildingManager>().transform);
    }
}
