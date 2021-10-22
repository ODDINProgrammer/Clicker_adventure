using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : ShopItemButton
{
    [Header("Item")]
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private int itemDamage;

    protected override void Awake()
    {
        itemSprite = itemSettings.ShopItemVisual;
        base.Awake();
    }
    public override void BuyItem()
    {
        aGameManager.aWeaponHandler.ChangeWeapon(itemDamage, itemSprite);
        base.BuyItem();
    }
}
