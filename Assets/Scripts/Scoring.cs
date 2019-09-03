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

            scoreText.GetComponent<Text>().text = "";

        }
        else if (points == 1)
        {

            scoreText.GetComponent<Text>().text = points + " Cube";

        }
        else
        {

            scoreText.GetComponent<Text>().text = points + " Cubes";

        }

    }


}
