using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public void HardLevel()
    {
        SceneManager.LoadScene("HardGameScene");
    }
    public void EasyLevel()
    {
        SceneManager.LoadScene("EasyGameScene");
    }
}
