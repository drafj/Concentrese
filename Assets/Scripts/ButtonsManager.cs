using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public void ImposibleLevel()
    {
        SceneManager.LoadScene("ImposibleGameScene");
        General.time = 60;
    }
    public void HardLevel()
    {
        SceneManager.LoadScene("HardGameScene");
        General.time = 80;
    }
    public void EasyLevel()
    {
        SceneManager.LoadScene("EasyGameScene");
        General.time = 80;
    }
}
