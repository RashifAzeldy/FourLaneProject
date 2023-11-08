using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator playerAnim;
    [SerializeField] EntityStats playerStats;
    [SerializeField] BoxCollider rightHandCollider;
    [SerializeField] BoxCollider leftHandCollider;

    PlayerStatus status;

    UsedHand m_usedHand;
    bool canChangeHand;


    private void Start()
    {
        status = GetComponent<PlayerStatus>();
        m_usedHand = UsedHand.Left;

        rightHandCollider.enabled = false;
        leftHandCollider.enabled = false;
    }

    void Update()
    {
        Attack();

        if ( Input.GetKeyDown(KeyCode.Escape) )
        {
            status.PlayerHighscore = GameFunctionLibrary.Instance.CheckHighScore(status.PlayerScore, status.PlayerHighscore);
            UIManager.Instance.GameOver(status.PlayerScore, status.PlayerHighscore);
        }
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
            if ( m_usedHand == UsedHand.Left )
            {
                rightHandCollider.enabled = true;
            }
            else
            {
                leftHandCollider.enabled = true;
            }
            GameFunctionLibrary.Instance.CheckPunchAnimation(m_usedHand, playerAnim);
            StartCoroutine(ColliderActiveDelay());
            ChangeHand();
        }
    }

    IEnumerator ColliderActiveDelay()
    {
        while ( playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.5f )
        {
            yield return null;
        }

        rightHandCollider.enabled = false;
        leftHandCollider.enabled = false;
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