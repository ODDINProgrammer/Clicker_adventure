using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class HealthPotion : MonoBehaviour
{
    [Header("Potion")]
    [SerializeField] internal int PotionsAmount;
    [SerializeField] internal int HPRestore;
    [Header("Accessors")]
    [SerializeField] private GameManager aGameManager;
    [Header("Audio")]
    [SerializeField] AudioSource audio;

    public void UsePotion()
    {
        if (PotionsAmount > 0 && aGameManager.CurrentHP < aGameManager.MaxHP)
        {
           audio.Play();
           PotionsAmount--;
           aGameManager.aUiHandler.UpdateUI();
           aGameManager.ModifyHP(HPRestore);
        }

    }

    public void AddPotion(int _value)
    {
        PotionsAmount += _value;
    }
}
