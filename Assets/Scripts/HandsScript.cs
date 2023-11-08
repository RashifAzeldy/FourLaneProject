using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsScript : MonoBehaviour
{
    [SerializeField] EntityStats userStats;

    private void OnTriggerEnter( Collider other )
    {
        if ( other.tag == "Enemy" && other.GetComponent<EnemyScript>() ||
           other.tag == "Player" && other.GetComponent<PlayerController>() )
        {
            // Apply Damage to Enemy
            GameFunctionLibrary.Instance.ApplyAttackDamage(userStats, other.GetComponent<EntityStats>());
        }
    }
}

public enum UsedHand
{
    Right,
    Left
}

