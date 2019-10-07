using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    public Material visibleMaterial1;
    public Material visibleMaterial2;
    public Material visibleMaterial3;
    public Material visibleMaterial4;
    public Material visibleMaterial5;
    public Material visibleMaterial6;
    public Material visibleMaterial7;
    public Material visibleMaterial8;

    public static Material staticMaterial1;
    public static Material staticMaterial2;
    public static Material staticMaterial3;
    public static Material staticMaterial4;
    public static Material staticMaterial5;
    public static Material staticMaterial6;
    public static Material staticMaterial7;
    public static Material staticMaterial8;

    private void Awake() 
    {
        staticMaterial1 = visibleMaterial1;
        staticMaterial2 = visibleMaterial2;
        staticMaterial3 = visibleMaterial3;
        staticMaterial4 = visibleMaterial4;
        staticMaterial5 = visibleMaterial5;
        staticMaterial6 = visibleMaterial6;
        staticMaterial7 = visibleMaterial7;
        staticMaterial8 = visibleMaterial8;
    }
}
