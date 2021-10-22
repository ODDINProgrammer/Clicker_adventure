using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    [Header("Animator")]
    [SerializeField] private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    protected override void Death()
    {
        base.Death();
    }

    internal override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _animator.Play("EnemyAttack");
    }
}
