using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardLevel : MonoBehaviour
{
    public Text attemptsText;
    public static int attemptsCounter;
    void Awake()
    {
        attemptsCounter = 10;
    }

    void Update()
    {
        if (attemptsText != null)
            attemptsText.text = "Attempts Remaining: " + attemptsCounter;
        else
            attemptsCounter = 10;
    }
}
