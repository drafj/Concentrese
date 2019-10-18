using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsControler : MonoBehaviour
{
    public Image timeUp;//imagen de derrota
    public Text FinalText;//texto que muestra el mensaje final ("you win" y "you lose")
    public bool show = false;//booleano que gira los cubos
    public bool materialFinded = false;//variable para hacer parar el while que asigna los materiales
    public static bool lockMouse = false;//booleano que bloquea el mouse para que solo se puedan voltear dos cubos consecutivos
    public static bool lockTime = false;//bloquea el tiempo cuando se acaba el juego
    public int textureRand;//randomizador que escoge el material
    public static int[] counters = new int[8];//contador para poner un mismo material una cantidad maxima de dos veces
    public CubesID mID;//se instancia el enum para asignarle las posiciones a los cubos

    void Awake()
    {
        for (int i = 0; i < 8; i++)
        {
            counters[i] = 0;
        }
        lockMouse = false;
        lockTime = false;
        textureRand = Random.Range(0,8);
        timeUp = GameObject.Find("TimeUp").GetComponent<Image>();
        FinalText = GameObject.Find("FinalText").GetComponent<Text>();
    }
    void Start()
    {
        timeUp.GetComponent<Image>().gameObject.SetActive(false);

        while (!materialFinded)
        {
            switch (textureRand)
            {
                case 0:
                    if (counters[0] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[0];
                        ++counters[0];
                        materialFinded = true;
                        mID = CubesID.C1;
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 1:
                    if (counters[1] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[1];
                        ++counters[1];
                        materialFinded = true;
                        mID = CubesID.C2;
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 2:
                    if (counters[2] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[2];
                        ++counters[2];
                        materialFinded = true;
                        mID = CubesID.C3;
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 3:
                    if (counters[3] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[3];
                        ++counters[3];
                        materialFinded = true;
                        mID = CubesID.C4;
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 4:
                    if (counters[4] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[4];
                        ++counters[4];
                        materialFinded = true;
                        mID = CubesID.C5;
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 5:
                    if (counters[5] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[5];
                        ++counters[5];
                        materialFinded = true;
                        mID = CubesID.C6;
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 6:
                    if (counters[6] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[6];
                        ++counters[6];
                        materialFinded = true;
                        mID = CubesID.C7;
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
                case 7:
                    if (counters[7] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[7];
                        ++counters[7];
                        materialFinded = true;
                        mID = CubesID.C8;
                    }
                    else
                        textureRand = Random.Range(0, 8);
                    break;
            }
        }
    
    }

    void OnMouseDown()
    {
        if (!lockMouse)
        {
            show = true;
            if (General.cubesVerificator[0] == null)
                General.cubesVerificator[0] = gameObject;
            else if (gameObject != General.cubesVerificator[0])
            {
                General.cubesVerificator[1] = gameObject;
                Verification();
            }
        }
    }

    public void Verification()
    {
        if (General.cubesVerificator[0].GetComponent<CardsControler>().mID == General.cubesVerificator[1].GetComponent<CardsControler>().mID)
        {
            lockMouse = true;
            Invoke("CubeDestroy", 1.7f);
        }
        else
        {
            lockMouse = true;
            if (General.cubesVerificator[0] != null && General.cubesVerificator[1] != null)
            Invoke("NoConcidence", 1.7f);
        }
    }

    public void CubeDestroy()
    {
        Destroy(General.cubesVerificator[0].gameObject);
        Destroy(General.cubesVerificator[1].gameObject);
        General.cubesVerificator[0] = null;
        General.cubesVerificator[1] = null;
        lockMouse = false;
        ++General.winConditional;
    }

    public void NoConcidence()
    {
        General.cubesVerificator[0].gameObject.GetComponent<CardsControler>().show = false;
        General.cubesVerificator[1].gameObject.GetComponent<CardsControler>().show = false;
        General.cubesVerificator[0] = null;
        General.cubesVerificator[1] = null;
        --DificultLevel.attemptsCounter;
        lockMouse = false;
    }

    private void Update() 
    {
        if (General.time <= 0 || DificultLevel.attemptsCounter == 0)
        {
            lockMouse = true;
            lockTime = true;
            if (General.cubesVerificator[0] != null)
                General.cubesVerificator[0].gameObject.GetComponent<CardsControler>().show = false;
            if (General.cubesVerificator[1] != null)
                General.cubesVerificator[1].gameObject.GetComponent<CardsControler>().show = false;
            timeUp.GetComponent<Image>().gameObject.SetActive(true);
            FinalText.text = "You Lose";
        }

        if (show)
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.up * 180, 2 * Time.deltaTime));
        else
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.zero, 2 * Time.deltaTime));
    }
}

public enum CubesID {C1,C2,C3,C4,C5,C6,C7,C8}//enum que se asignan a los cubos para despues compararlos