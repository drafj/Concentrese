using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public void ImposibleLevel()
    {
        General.time = 60;
        DificultLevel.attemptsCounter = 8;
        SceneManager.LoadScene("ImposibleGameScene");
    }
    public void HardLevel()
    {
        General.time = 80;
        DificultLevel.attemptsCounter = 10;
        SceneManager.LoadScene("HardGameScene");
    }
    public void EasyLevel()
    {
        General.time = 80;
        DificultLevel.attemptsCounter = 10;
        SceneManager.LoadScene("EasyGameScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
