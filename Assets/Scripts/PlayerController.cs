using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator playerAnim;
    [SerializeField] EntityStats playerStats;

    UsedHand m_usedHand;
    bool canChangeHand;

    private void Start()
    {
        m_usedHand = UsedHand.Left;
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if ( Input.GetKeyDown(KeyCode.UpArrow) )
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            canChangeHand = true;
        }
        else if ( Input.GetKeyDown(KeyCode.DownArrow) )
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            canChangeHand = true;
        }
        else if ( Input.GetKeyDown(KeyCode.RightArrow) )
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            canChangeHand = true;
        }
        else if ( Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            canChangeHand = true;
        }

        if ( canChangeHand )
        {
            canChangeHand = false;
            GameFunctionLibrary.Instance.CheckPunchAnimation(m_usedHand, playerAnim);
            ChangeHand();
        }
    }

    void ChangeHand()
    {
        if ( m_usedHand == UsedHand.Left )
        {
            m_usedHand = UsedHand.Right;
        }
        else
        {
            m_usedHand = UsedHand.Left;
        }
    }
}