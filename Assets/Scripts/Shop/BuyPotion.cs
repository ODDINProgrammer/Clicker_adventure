using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPotion : ShopItemButton
{
    public override void BuyItem()
    {
        aGameManager.aPotionHandler.AddPotion(1);
        base.BuyItem();
    }
}
