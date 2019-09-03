using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCube : MonoBehaviour
{

    public AudioSource collectSound;

    void OnTriggerEnter(Collider other)
    {

        collectSound.Play();
        Scoring.points += 1;
        Destroy(gameObject);

    }


}
