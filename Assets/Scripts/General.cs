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
        if (General.winConditional == 8)
            win.GetComponent<Image>().gameObject.SetActive(true);
    }
}
