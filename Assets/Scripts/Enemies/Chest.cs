using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Enemy
{
    protected override void PotionDrop()
    {
        //  HIGHER AMOUNT OF DROP
        int random = Random.Range(aEnemyDrop.potions_to_drop - 2, aEnemyDrop.potions_to_drop);
        aGameManager.aPOPupHandler.PopUPPotions(random);
    }
}
