using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public GameObject textBox;
    public string input;

    void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);
        textBox.GetComponent<Text>().text = input;

    }

}
