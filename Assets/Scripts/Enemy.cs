using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float damage;

    public float distanceToEnd = 0f;

    public virtual void OnDeath() { }

    public void DoDamage()
    {
        // Hurt the player IDK
    }
}
