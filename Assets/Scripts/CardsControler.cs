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
        for (int i = 0; i < 8; i++)//reinicia el array ya que es estatico y las variable estaticas no se reinican cuando se carga la escena
        {
            counters[i] = 0;
        }
        lockMouse = false;//reinicia la variable
        lockTime = false;//reinicia la variable
        textureRand = Random.Range(0,8);//randomiza la variable para escoger el material de manera random
        timeUp = GameObject.Find("TimeUp").GetComponent<Image>();//encuentra la imagen de derrota
        FinalText = GameObject.Find("FinalText").GetComponent<Text>();//encuentra el texto del fin del juego
    }
    void Start()
    {
        timeUp.GetComponent<Image>().gameObject.SetActive(false);//se oculta el cartel de derrota para mostrarlo en caso de que el jugador pierda

        while (!materialFinded)//while que encuentra el material y solo agrega dos materiales de cada uno
        {
            switch (textureRand)
            {
                case 0:
                    if (counters[0] < 2)
                    {
                        gameObject.GetComponent<Renderer>().material = General.staticMaterials[0];//se agrega el material del array de materiales estaticos del script general
                        ++counters[0];//cuando encuentra el material se suma al contador de materiales agregados
                        materialFinded = true;//cuando encuentra el material para el while
                        mID = CubesID.C1;//cuando encuentra el material se le da una identidad con un enum
                    }
                    else
                        textureRand = Random.Range(0, 8);//si este material ya esta agregado dos veces vuelve a empezar el while hasta que encuentre material
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
        if (!lockMouse)//solo entra cuando la variable que bloquea el mouse esta falso
        {
            show = true;//pone el booloeano show verdadero para que voltee el cubo
            if (General.cubesVerificator[0] == null)//pregunta si la posicion 0 del array de gameobjects esta nulo, si es asi agrega el cubo a ese array para despues verificarlos
                General.cubesVerificator[0] = gameObject;
            else if (gameObject != General.cubesVerificator[0])//si la posicion 0 esta llena entra a la posicion 1 y verifica los gameobjects de las dos posiciones (puse una condicional que consiste en que solo entre en la posicion uno cuando el 0 es diferente al que entrara a la posicion 1)
            {
                General.cubesVerificator[1] = gameObject;
                Verification();
            }
        }
    }

    public void Verification()//funcion que verifica si los dos cubos coinciden o no
    {
        if (General.cubesVerificator[0].GetComponent<CardsControler>().mID == General.cubesVerificator[1].GetComponent<CardsControler>().mID)//verifica si el cubo 0 tiene el mismo enum que el cubo 1 y si es asi los destruye
        {
            lockMouse = true;//bloquea el mouse para que no se puedan seleccionar mas cubos que los dos seleccionados
            Invoke("CubeDestroy", 1.7f);//invoca la funcion que destruye los cubos despues de un tiempo para que su destruccion no sea inmediata ya que no se podria ver la coincidencia de los cubos
        }
        else
        {
            lockMouse = true;//bloquea el mouse para que no se puedan seleccionar mas cubos que los dos seleccionados
            if (General.cubesVerificator[0] != null && General.cubesVerificator[1] != null)
            Invoke("NoConcidence", 1.7f);//invoke que despues de un tiempo voltea los cubos de nuevo para que siga el juego
        }
    }

    public void CubeDestroy()//funcion que destruye los cubos
    {
        Destroy(General.cubesVerificator[0].gameObject);
        Destroy(General.cubesVerificator[1].gameObject);
        General.cubesVerificator[0] = null;
        General.cubesVerificator[1] = null;
        lockMouse = false;//desbloquea el mouse para proseguir el juego
        ++General.winConditional;//aumenta el contador que al llegar a 8 ganas el juego(8 porque para ganar se deben hacer 8 aciertos
    }

    public void NoConcidence()//funcion que voltea los cubos que no coinciden
    {
        General.cubesVerificator[0].gameObject.GetComponent<CardsControler>().show = false;
        General.cubesVerificator[1].gameObject.GetComponent<CardsControler>().show = false;
        General.cubesVerificator[0] = null;
        General.cubesVerificator[1] = null;
        --DificultLevel.attemptsCounter;//en el nivel dificil e imposible se le resta un intento cuando los cubos no coinciden
        lockMouse = false;//desbloquea el mouse para proseguir el juego
    }

    private void Update() 
    {
        if (General.time <= 0 || DificultLevel.attemptsCounter == 0)//si el tiempo llega a 0 o los intentos llegan a 0 pierde el jugador
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