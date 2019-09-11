using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{

    public GameObject scoreText;
    public static int points;

    void Update()
    {
        PlayerDamage.health += 5f;
        
        if (points <= 0)
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

        // if playerDamaged ()
        // {
        //     points = points - 5;
            
        // }

    }


}
