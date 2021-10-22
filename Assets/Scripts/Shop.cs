using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI GoldText;
    [Header("Accessors")]
    [SerializeField] private GameManager aGameManager;
    [SerializeField] private GameObject aShopScreen;

    public void UpdateShopGoldText()
    {
        GoldText.SetText(aGameManager.Gold.ToString());
    }
}
