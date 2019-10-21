using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class General : MonoBehaviour
{
    public Material[] visibleMaterials = new Material[8];//array de materiales que es publico para agregar los materiales desde el inspector
    public static Material[] staticMaterials = new Material[8];//array de materiales estatico para usarlo desde otro script sin necesidad de instanciarlo
    public static GameObject[] cubesVerificator = new GameObject[2];//array de gameobjects para almacenar temporalmente los cubos a verificar
    public Image win;//image que se muestra al fin del juego
    public Text timeText;//texto que muestra el tiempo
    public Text FinalText;//texto final que te dice si perdiste o ganaste

    public static float time;//variable que muestra el tiempo
    public static int winConditional;//variable entera que cuando llega hasta 8 gana el jugador


    private void Awake() 
    {
        winConditional = 0;//se reinica la variable por ser estatica y cuando se cargan las escenas no se reinica automaticamente
        for (int i = 0; i < 8; i++)//asigna los materiales visibles con los materiales estaticos
        {
            staticMaterials[i] = visibleMaterials[i];
        }
        win.GetComponent<Image>().gameObject.SetActive(false);//oculta la imagen final
        FinalText.text = "";//borra lo que haya en el texto final
    }

    void Update()
    {
        if (winConditional == 8)//si llega a 8 gana
        {
            CardsControler.lockTime = true;
            win.GetComponent<Image>().gameObject.SetActive(true);
            FinalText.text = "You Win";
        }

        if (!CardsControler.lockTime)//hace que el tiempo sea regresivo
            time -= Time.deltaTime;

        timeText.text = "Time Remaining: " + time.ToString("f0");//muestra el tiempo en el texto
    }
}
