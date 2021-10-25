using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

internal class UIHandler : MonoBehaviour
{
    [Header("Text objects")]
    [SerializeField] TextMeshProUGUI DamageText;
    [SerializeField] TextMeshProUGUI ExpText;
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] TextMeshProUGUI GoldText;
    [SerializeField] TextMeshProUGUI HealthbarText;
    [SerializeField] TextMeshProUGUI PotionText;
    [SerializeField] TextMeshProUGUI ShopGoldText;
    [SerializeField] TextMeshProUGUI ArmorText;
    [Header("Accessors")]
    [SerializeField] private GameManager aGameManager;

    private void Awake()
    {
        aGameManager = GetComponent<GameManager>();
    }

    internal void UpdateUI()
    {
        DamageText.SetText(aGameManager.CurrentDamage.ToString() + " / " + aGameManager.MaxDamage.ToString());

        if (aGameManager.Level < aGameManager.RequiredExpToLevel.Length)
            ExpText.SetText(aGameManager.CurrentEXP.ToString() + " / " + aGameManager.RequiredExpToLevel[aGameManager.Level].ToString());
        else
            ExpText.SetText("MAX EXP");

        LevelText.SetText(aGameManager.Level.ToString());

        GoldText.SetText(aGameManager.Gold.ToString());

        HealthbarText.SetText(aGameManager.CurrentHP.ToString() + " / " + aGameManager.MaxHP.ToString());

        PotionText.SetText(aGameManager.aPotionHandler.PotionsAmount.ToString());

        ShopGoldText.SetText(aGameManager.Gold.ToString());

        ArmorText.SetText(aGameManager.CurrentArmor.ToString() + " / " + aGameManager.MaxArmor.ToString());
    }
}
