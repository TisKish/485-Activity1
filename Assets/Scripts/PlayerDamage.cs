using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    Image Health;
    float maxHealth = 100f;
    public static float health;

    
    void Start()
    {
        Health = GetComponent<Image> ();
        health = maxHealth;
    }

    // Damage goes below
    void Update()
    {
        Health.fillAmount = health / maxHealth;
        //Example damage: Use it outside of this script in mob scripts
        // PlayerDamage.health -= 10f;
    }
}
