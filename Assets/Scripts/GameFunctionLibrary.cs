using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFunctionLibrary : MonoBehaviour
{
    public static GameFunctionLibrary Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ApplyAttackDamage(EntityStats attacker, EntityStats target )
    {
        target.EntityHealth -= attacker.EntityAttackDamage;
    }

    public void CheckPunchAnimation(UsedHand usedHand, Animator anim)
    {
        if ( usedHand == UsedHand.Left )
        {
            anim.SetTrigger("Right_Punch");
        }
        else
        {
            anim.SetTrigger("Left_Punch");
        }
    }
}
