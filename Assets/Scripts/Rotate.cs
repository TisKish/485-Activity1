using System.Collections;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float rotateSpeed = 3.0f;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(rotateSpeed, rotateSpeed, rotateSpeed);

    }
}
