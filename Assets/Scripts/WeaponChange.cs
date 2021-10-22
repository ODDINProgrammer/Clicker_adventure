using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class WeaponChange : MonoBehaviour
{
    [Header("Accessors")]
    [SerializeField] private GameManager aGameManager;

    private void Awake()
    {
        aGameManager = GetComponent<GameManager>();
    }
    internal void ChangeWeapon(int _damage, Sprite _sprite)
    {
        aGameManager.CurrentDamage += _damage;
        aGameManager.MaxDamage += _damage;

        aGameManager.aPlayerButton.image.sprite = _sprite;
    }
}
