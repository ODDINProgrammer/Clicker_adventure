using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Enemy
{
    protected override void PotionDrop()
    {
        //  HIGHER AMOUNT OF DROP
        int random = Random.Range(potion_Max_amount_to_drop - 2, potion_Max_amount_to_drop);
        aGameManager.aPOPupHandler.PopUPPotions(random);
    }
}
