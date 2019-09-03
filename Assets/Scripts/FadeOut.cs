using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{

    public int timer = 5;
    private int counter = 0;

    void Update()
    {

        if (gameObject.GetComponent<Text>().text != "")
        {

            if (counter == 0)
            {

                counter = 1;

            }
           
        }
        if (counter > 0)
        {

            counter += 1;

        }
        if (counter == timer)
        {

            Destroy(gameObject);

        }

    }
}
