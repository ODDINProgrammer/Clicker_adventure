using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    [Header("Special abilities")]
    [SerializeField] private int ChanceToReduceDamage;
    [Header("Animator")]
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    protected override void Death()
    {
        if (aGameManager.CurrentDamage != 1 && ChanceToReduceDamage > 0)
        {
            float random = Random.Range(0, 101);
            if (random <= ChanceToReduceDamage) 
                aGameManager.aPOPupHandler.PopUPDamageChange(-1, aGameManager.aPOPupHandler.GO_damageRed);
        }
        base.Death();
    }

    internal override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _animator.Play("EnemyAttack");
    }
}
