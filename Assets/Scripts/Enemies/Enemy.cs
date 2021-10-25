using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Parametrs")]
    [SerializeField] internal int CurrentHP;
    [SerializeField] internal int MaxHP;
    [SerializeField] internal int Damage;
    [Header("EXP")]
    [SerializeField] internal int Exp;
    [Header("Gold")]
    [SerializeField] internal int GoldOnDeath;
    [Header("Accessors")]
    [SerializeField] internal GameManager aGameManager;
    [SerializeField] internal EnemyDrop aEnemyDrop;
    [SerializeField] internal Animator animator;
    [SerializeField] internal Slider healthbar;
    [SerializeField] internal TextMeshProUGUI HPText;
    [Header("Audio")]
    [SerializeField] internal AudioSource audio;

    internal virtual void TakeDamage(int damage)
    {
        audio.Play();

        CurrentHP -= damage;

        HPText.SetText(CurrentHP.ToString() + " / " + MaxHP.ToString());
        healthbar.value = CurrentHP;

        if(CurrentHP <= 0)
        {
            Death();
            return;
        }
        aGameManager.TakeDamage(Damage);
    }

    protected virtual void Death()
    {
        //  DECIDE IF NEED TO GIVE POTIONS
        PotionDrop();
        aGameManager.CountKill(Exp, GoldOnDeath);
        gameObject.SetActive(false);
    }
    protected virtual void OnEnable()
    {
        aGameManager = FindObjectOfType<GameManager>();
        aEnemyDrop = GetComponent<EnemyDrop>();
        if (aEnemyDrop == null)
            return;
        animator = GetComponent<Animator>();

        //  RESET ENEMY
        CurrentHP = MaxHP;
        healthbar.maxValue = MaxHP;
        healthbar.value = MaxHP;
        HPText.SetText(CurrentHP.ToString() + " / " + MaxHP.ToString());
        aGameManager.SetEnemy(this.gameObject);
    }

    private void OnDisable()
    {
        aGameManager.SetEnemy(null);
        if (animator == null) return;
        animator.keepAnimatorControllerStateOnDisable = true;
    }

    protected virtual void PotionDrop()
    {
        int random = Random.Range(0, 100);
        if (random <= aEnemyDrop.potion_drop_chance)
        {
            //  GENERATE AMOUNT TO GIVE
            random = Random.Range(1, aEnemyDrop.potions_to_drop);
            aGameManager.aPOPupHandler.PopUPPotions(random);
        }
    }
}
