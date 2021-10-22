using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : ShopItemButton
{
    protected override void Update()
    {
        if (aGameManager.CurrentDamage == aGameManager.MaxDamage)
        {
            ItemButton.interactable = false;
            return;
        }
        base.Update();
    }
    public override void BuyItem()
    {
        aGameManager.CurrentDamage++;
        base.BuyItem();
    }
}
