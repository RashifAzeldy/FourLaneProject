using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Transform player;
    [SerializeField] float attackDistance = 1.0f;

    NavMeshAgent agent;
    UsedHand hand;
    bool isAttacking;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.position;

        hand = UsedHand.Left;
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
    }

    IEnumerator EnemyAttacking()
    {
        isAttacking = true;
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
    }
}
