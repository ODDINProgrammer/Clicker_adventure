using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "", menuName = "CreateShopItem")]
public class ShopItemScriptable : ScriptableObject
{
    public string ShopItemName;
    [TextArea(1,3)]
    public string ShopItemDescription;
    public int ShopItemPrice;
    public Sprite ShopItemVisual;
}
