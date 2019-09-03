using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HiddenPassage : MonoBehaviour
{

    public GameObject textBox;
    public int pointLimit;

    private void Update()
    {
        
        if (Scoring.points >= pointLimit)
        {

            Destroy(gameObject);
            textBox.GetComponent<Text>().text = "A passage has opened up";
            
        }

    }

}
