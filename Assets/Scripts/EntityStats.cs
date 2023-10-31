using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    [SerializeField] float m_health;
    [SerializeField] float m_attackDamage;

    public float EntityHealth { get { return m_health; } set { m_health = value; } }
    public float EntityAttackDamage { get { return m_attackDamage; } set { m_attackDamage = value; } }
}
