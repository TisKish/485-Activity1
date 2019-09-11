using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactiveTarget : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public Slider slider;
    public GameObject healthBarUI;

    private int materialStart;
    public Material[] materials;
    Renderer rend;

    public void Start()
    {
        materialStart = 0;

        maxHealth = 3;

        health = maxHealth;

        slider.value = CalculateHealth();

        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[materialStart];

        healthBarUI.SetActive(false);
    }

    private void Update()
    {
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void ReactToHit()
    {
        GetComponent<Rigidbody>().velocity = Vector3.up * 3;

        health--;

        slider.value = CalculateHealth();

        rend.sharedMaterial = materials[++materialStart];

        if (health <= 0)
        {
            rend.sharedMaterial = materials[3];

            WanderingAI behavior = GetComponent<WanderingAI>();
            if (behavior != null)
            {
                behavior.SetAlive(false);
            }
            StartCoroutine(Die());
        }

    }

    private IEnumerator Die()
    {
        GetComponent<Rigidbody>().velocity = Vector3.up * 8;

        yield return new WaitForSeconds(1.5f);

        Scoring.points++;

        Destroy(this.gameObject);
    }

    private float CalculateHealth()
    {
        return health / maxHealth;
    }
}
