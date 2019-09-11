using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 2.0f;
    public float damage = 1;
    public float maxAngle = 45;
    public float maxRadius = 10;

    private bool _alive;

    private Transform player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerCharacter>().transform;
    }

    private void Start()
    {
        _alive = true;
    }

    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            if (FOVDetection.InFOV(transform, player, maxAngle, maxRadius))
            {
                if (transform.position != player.position)
                {
                    transform.LookAt(player.transform);
                    transform.position += transform.forward * (speed * 2) * Time.deltaTime;
                }
            }
            else
            {
                Ray ray = new Ray(transform.position, transform.forward);

                RaycastHit hit;
                if (Physics.SphereCast(ray, 0.75f, out hit))
                {
                    if (hit.distance < obstacleRange)
                    {
                        float angle = Random.Range(-110, 110);
                        transform.Rotate(0, angle, 0);
                    }
                }
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerCharacter pc = FindObjectOfType<PlayerCharacter>();

            if (pc != null)
            {
                pc.Hurt(1);
            }

            Destroy(gameObject);
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
