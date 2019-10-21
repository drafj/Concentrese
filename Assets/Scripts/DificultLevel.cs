using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DificultLevel : MonoBehaviour
{
    public Text attemptsText;//texto que muestra el numero de intentos restantes
    public static int attemptsCounter;//contador de intentos restantes

    void Update()
    {
        if (attemptsText != null)//condicional que consiste en que si el texto fue agregado en el inspector se muestran los intentos y si no los intentos siempre seran 10 (el nivel facil es el unico que no se le agrega el texto en el inspector)
            attemptsText.text = "Attempts Remaining: " + attemptsCounter;
        else
            attemptsCounter = 10;
    }
}
