using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemButton : MonoBehaviour
{
    [Header("Scriptable object")]
    [SerializeField] internal ShopItemScriptable itemSettings;
    [Header("Item values")]
    [SerializeField] private string itemName;
    [SerializeField] private int itemPrice;
    [Header("Item game objects references")]
    [SerializeField] private TextMeshProUGUI ItemNameText;
    [SerializeField] private TextMeshProUGUI ItemPriceText;
    [SerializeField] private TextMeshProUGUI ItemDescriptionText;
    [SerializeField] internal Button ItemButton;
    [Header("Audio")]
    [SerializeField] private AudioSource audio;
    [Header("Accessors")]
    [SerializeField] internal GameManager aGameManager;

    protected virtual void Awake()
    {
        itemName = itemSettings.ShopItemName;
        itemPrice = itemSettings.ShopItemPrice;

        ItemNameText.SetText(itemName);
        ItemPriceText.SetText(itemPrice.ToString());
        ItemDescriptionText.SetText(itemSettings.ShopItemDescription);

        aGameManager = FindObjectOfType<GameManager>();
        ItemButton = GetComponentInChildren<Button>();

        ItemButton.image.sprite = itemSettings.ShopItemVisual;

        audio = transform.GetComponentInParent<AudioSource>();
    }

    protected virtual void Update()
    {
        if (aGameManager.Gold >= itemPrice)
            ItemButton.interactable = true;
        else
            ItemButton.interactable = false;
    }

    public virtual void BuyItem()
    {
        audio.Play();

        aGameManager.Gold -= itemPrice;

        aGameManager.aUiHandler.UpdateUI();
        
    }
}
