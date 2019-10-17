﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class General : MonoBehaviour
{
    public Material[] visibleMaterials = new Material[8];
    public static Material[] staticMaterials = new Material[8];
    public static GameObject[] cubesVerificator = new GameObject[2];
    public Image win;
    public Text timeText;
    public Text FinalText;

    public static float time;
    public static int winConditional;


    private void Awake() 
    {
        winConditional = 0;
        for (int i = 0; i < 8; i++)
        {
            staticMaterials[i] = visibleMaterials[i];
        }
        win.GetComponent<Image>().gameObject.SetActive(false);
        FinalText.text = "";
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene("MenuScene");

        if (Input.GetKeyDown(KeyCode.LeftShift))
            DificultLevel.attemptsCounter = 10;

        if (Input.GetKeyDown(KeyCode.LeftControl))
            time = 80;

        if (winConditional == 8)
        {
            CardsControler.lockTime = true;
            win.GetComponent<Image>().gameObject.SetActive(true);
            FinalText.text = "You Win";
        }

        if (!CardsControler.lockTime)
            time -= Time.deltaTime;

        timeText.text = "Time Remaining: " + time.ToString("f0");
    }
}
