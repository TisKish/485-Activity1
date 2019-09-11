using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingProjectile : MonoBehaviour
{
    GameObject m_target;
    GameObject m_launcher;
    int m_damage;
    float speed = 5.0f;

    Vector3 m_lastKnownPosition;

    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_target)
        {
            m_lastKnownPosition = m_target.transform.position;
        }
        else
        {
            if (transform.position == m_lastKnownPosition)
            {
                Destroy(gameObject);
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, m_lastKnownPosition, speed * Time.deltaTime);
    }

    public void FireProjectile(GameObject launcher, GameObject target, int damage, float attackSpeed)
    {
        if (target)
        {
            m_target = target;
            m_lastKnownPosition = target.transform.position;
            m_launcher = launcher;
            m_damage = damage;
        }
    }
}
