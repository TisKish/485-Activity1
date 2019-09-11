using System.Collections;
using System.Collections.Generic;
using static System.Math;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public float fireRate;
    public int damage;
    public float fieldOfView;
    public bool beam;
    public GameObject projectile;
    public List<GameObject> projectileSpawns;
    public GameObject m_target;
    double rangeToTarget;
    public double maxRange;
    private AudioSource audio;

    List<GameObject> m_lastProjectiles = new List<GameObject>();
    float m_fireTimer = 0.0f;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rangeToTarget = Sqrt(Pow(m_target.transform.position.x - transform.position.x, 2)
            + Pow(m_target.transform.position.y - transform.position.y, 2)
            + Pow(m_target.transform.position.z - transform.position.z, 2));
        if (rangeToTarget <= maxRange)
        {
            if (!m_target)
            {
                if (beam)
                    RemoveLastProjectiles();

                return;
            }

            if (beam && m_lastProjectiles.Count <= 0)
            {
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(m_target.transform.position - transform.position));

                if (angle < fieldOfView)
                {
                    SpawnProjectiles();
                }
            }
            else if (beam && m_lastProjectiles.Count > 0)
            {
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(m_target.transform.position - transform.position));

                if (angle > fieldOfView)
                {
                    RemoveLastProjectiles();
                }
            }
            else
            {
                m_fireTimer += Time.deltaTime;

                if (m_fireTimer >= fireRate)
                {
                    float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(m_target.transform.position - transform.position));

                    if (angle < fieldOfView)
                    {
                        SpawnProjectiles();

                        m_fireTimer = 0.0f;
                    }
                }
            }
        }
    }

    void SpawnProjectiles()
    {
        if (!projectile)
        {
            return;
        }

        m_lastProjectiles.Clear();

        for (int i = 0; i < projectileSpawns.Count; i++)
        {
            if (projectileSpawns[i])
            {
                GameObject proj = Instantiate(projectile, projectileSpawns[i].transform.position, Quaternion.Euler(projectileSpawns[i].transform.forward)) as GameObject;
                proj.GetComponent<TrackingProjectile>().FireProjectile(projectileSpawns[i], m_target, damage, fireRate);

                audio.Play();

                m_lastProjectiles.Add(proj);
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        m_target = target;
    }

    void RemoveLastProjectiles()
    {
        while (m_lastProjectiles.Count > 0)
        {
            Destroy(m_lastProjectiles[0]);
            m_lastProjectiles.RemoveAt(0);
        }
    }
}
