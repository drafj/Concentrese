using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class General : MonoBehaviour
{
    public Material[] visibleMaterials = new Material[8];
    public static Material[] staticMaterials = new Material[8];
    public static GameObject[] cubesVerificator = new GameObject[2];
    public Image win;
    public Text timeText;

    public static float time;
    public static int winConditional;


    private void Awake() 
    {
        for (int i = 0; i < 8; i++)
        {
            staticMaterials[i] = visibleMaterials[i];
        }
        win.GetComponent<Image>().gameObject.SetActive(false);
    }

    void Update()
    {
        if (winConditional == 8)
        {
            CardsControler.lockTime = true;
            win.GetComponent<Image>().gameObject.SetActive(true);
        }

        if (!CardsControler.lockTime)
            time -= Time.deltaTime;

        timeText.text = "Time Remaining: " + time.ToString("f0");
    }
}
