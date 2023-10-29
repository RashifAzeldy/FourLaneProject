using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator playerAnim;

    UsedHand m_usedHand;

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
            CheckPunchAnimation();
        }
        else if ( Input.GetKeyDown(KeyCode.DownArrow) )
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            CheckPunchAnimation();
        }
        else if ( Input.GetKeyDown(KeyCode.RightArrow) )
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            CheckPunchAnimation();
        }
        else if ( Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            CheckPunchAnimation();
        }
    }

    void CheckPunchAnimation()
    {
        if ( m_usedHand == UsedHand.Left )
        {
            // Play Right Hand Punch
            playerAnim.SetTrigger("Right_Punch");
            // Switch The Next Punch to Right
            m_usedHand = UsedHand.Right;
        }
        else
        {
            // Play Left Hand Punch
            playerAnim.SetTrigger("Left_Punch");
            // Switch The Next Punch to Left
            m_usedHand = UsedHand.Left;
        }
    }
}

enum UsedHand
{
    Right,
    Left
}
