using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public void ImposibleLevel()
    {
        SceneManager.LoadScene("ImposibleGameScene");
        CardsControler.time = 60;
    }
    public void HardLevel()
    {
        SceneManager.LoadScene("HardGameScene");
        CardsControler.time = 80;
    }
    public void EasyLevel()
    {
        SceneManager.LoadScene("EasyGameScene");
        CardsControler.time = 80;
    }
}
