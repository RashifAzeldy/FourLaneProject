using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsScript : MonoBehaviour
{
    [SerializeField] EntityStats userStats;

    private void OnTriggerEnter( Collider other )
    {
        if(other.tag == "Enemy" && other.GetComponent<EnemyAI>() )
        {
            // Apply Damage to Enemy
            Debug.Log("Hit, Damage : " + userStats.EntityAttackDamage);
        }else if (other.tag == "Player" && other.GetComponent<PlayerController>() )
        {
            //Apply Damage to Player
        }
    }
}

public enum UsedHand
{
    Right,
    Left
}

