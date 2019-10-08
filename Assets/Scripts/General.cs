using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    public Material[] visibleMaterials = new Material[8];
    public static Material[] staticMaterials = new Material[8];
    public static GameObject[] cubesVerificator = new GameObject[2];

    private void Awake() 
    {
        for (int i = 0; i < 8; i++)
        {
        staticMaterials[i] = visibleMaterials[i];
        }
    }
}
