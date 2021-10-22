using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

internal class PowerUp : MonoBehaviour
{
    [Header("10 Kills")]
    [SerializeField] private GameObject GO_ten;
    [SerializeField] private bool b_ten = false;
   
    [Header("100 Kills")]
    [SerializeField] private GameObject GO_hundred;
    [SerializeField] private bool b_hundred = false;
    
    [Header("DamageRed")]
    [SerializeField] internal GameObject GO_damageRed;
    
    [Header("Potions")]
    [SerializeField] internal GameObject GO_GivePotion;
    [SerializeField] internal TextMeshProUGUI _potion_text;
    
    [Header("Accessors")]
    [SerializeField] private GameManager aGameManager;

    private void Start()
    {
        aGameManager = GetComponent<GameManager>();
    }
    private void Update()
    {
        // POPUPS RECEIVED FOR KILLING CERTAIN AMOUNT OF ENEMIES
        switch (aGameManager.Enemieskilled)
        {
            case 10:
                if (!b_ten)
                {
                    b_ten = true;
                    PopUPDamageChange(1, GO_ten);
                }
                break;
            case 100:
                if (!b_hundred)
                {
                    b_hundred = true;
                    PopUPDamageChange(2, GO_hundred);
                }
                break;
            default:
                break;
        }
    }
    internal void PopUPDamageChange(int value, GameObject _GO)
    {
        _GO.SetActive(true);

        aGameManager.CurrentDamage += value;
        if (value > 0)
            aGameManager.MaxDamage += value;

        aGameManager.aUiHandler.UpdateUI();
    }

    internal void PopUPPotions(int _amount)
    {
        //  UPDATE TEXT IN POPUP FIELD
        _potion_text.SetText(_amount.ToString());
        //  ADD POTIONS
        aGameManager.aPotionHandler.AddPotion(_amount);
        //  ACTIVATE POPUP
        GO_GivePotion.SetActive(true);
        //  UPDATE UI
        aGameManager.aUiHandler.UpdateUI();
    }
}
