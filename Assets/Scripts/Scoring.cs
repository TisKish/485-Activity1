using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{

    public GameObject scoreText;
    public static int points;

    void Update()
    {

        if (points == 0)
        {

            scoreText.GetComponent<Text>().text = "Score: 0";

        }
        else if (points == 1)
        {

            scoreText.GetComponent<Text>().text = "Score: " + points;

        }
        else
        {

            scoreText.GetComponent<Text>().text = "Score: " + points;

        }

    }


}
