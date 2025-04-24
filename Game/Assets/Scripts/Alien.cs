using System;
using System.Collections;
using System.Collections.Specialized;
using UnityEngine;

public class Alien : MonoBehaviour
{
    // Health for alien established.
    // Originally different points for location shot, this is now a stretch goal.
    [SerializeField] private int alien_headHP = 120;
    [SerializeField] private int alien_bodyHP = 60;

    public int alien_HP { get; private set; }

    private void Start()
    {
        // Alien's total health.
        alien_HP = alien_headHP + alien_bodyHP;
    }
    // Checks the health of the alien, if 0 health left, it is dead and destroyed.
    public void TakeDamage(int amount)
    {
        alien_HP  -= amount;
        if (alien_HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
