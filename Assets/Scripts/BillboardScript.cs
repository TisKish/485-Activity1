using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour
{
    public GameObject myCamera;


    private void Awake()
    {
        Init();
    }

    void Update()
    {
        transform.LookAt(transform.position + myCamera.transform.rotation * Vector3.forward,
            myCamera.transform.rotation * Vector3.up);
    }

    void Init()
    {
        myCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
}
