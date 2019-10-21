using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour//este script controla todos los botones de todas las escenas
{
    public void ImposibleLevel()//este boton lleva al nivel "imposible"
    {
        General.time = 60;
        DificultLevel.attemptsCounter = 8;
        SceneManager.LoadScene("ImposibleGameScene");
    }
    public void HardLevel()//este boton lleva al nivel "dificil"
    {
        General.time = 80;
        DificultLevel.attemptsCounter = 10;
        SceneManager.LoadScene("HardGameScene");
    }
    public void EasyLevel()//este boton lleva al nivel "facil"
    {
        General.time = 80;
        DificultLevel.attemptsCounter = 10;
        SceneManager.LoadScene("EasyGameScene");
    }

    public void Menu()//este boton lleva al menu
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Quit()//este boton es para salir del juego
    {
        Application.Quit();
    }
}
