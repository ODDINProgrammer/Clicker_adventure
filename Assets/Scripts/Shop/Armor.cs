using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : ShopItemButton
{
    [Header("Armor")]
    [SerializeField] int armor_value;

    public override void BuyItem()
    {
        aGameManager.CurrentArmor += armor_value;
        aGameManager.MaxArmor += armor_value;

        aGameManager.aUiHandler.UpdateUI();

        base.BuyItem();
    }
}
