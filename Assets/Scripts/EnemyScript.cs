using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] EntityStats enemyStats;
    [SerializeField] Animator anim;
    [SerializeField] Transform player;
    [SerializeField] float attackDistance = 1.0f;

    [SerializeField] BoxCollider rightHand;
    [SerializeField] BoxCollider leftHand;

    NavMeshAgent agent;
    UsedHand hand;
    bool isAttacking;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.position;

        hand = UsedHand.Left;

        rightHand.enabled = false;
        leftHand.enabled = false;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer < attackDistance && !isAttacking)
        {
            agent.SetDestination(transform.position);
            StartCoroutine(EnemyAttacking());
        }
        else
        {
            agent.SetDestination(player.position);
        }

        if(enemyStats.EntityHealth <= 0 )
        {
            // The Enemy is Dead
            player.GetComponent<PlayerStatus>().PlayerScore++;
            gameObject.SetActive(false);
        }
    }

    IEnumerator EnemyAttacking()
    {
        isAttacking = true;
        rightHand.enabled = true;
        leftHand.enabled = true;
        GameFunctionLibrary.Instance.CheckPunchAnimation(hand, anim);
        yield return new WaitForSeconds(1f);
        if(hand == UsedHand.Left )
        {
            hand = UsedHand.Right;
        }
        else
        {
            hand = UsedHand.Left;
        }
        isAttacking = false;
        rightHand.enabled = false;
        leftHand.enabled = false;
    }
}
