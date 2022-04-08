using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void NewGame()
    {
        UIManager.Instance.OpenFade();
        Invoke("newgameinvoke", 1f);
    }

    void newgameinvoke()
    {
        SceneControl.Instance.NewGame();
    }
    public void Continue()
    {
        if (SaveManager.Instance.HasDate())
        {
            UIManager.Instance.OpenFade();
            Invoke("continueinvoke", 1f);
        }
        else
            Debug.Log("NoSaveDate");
    }
    void continueinvoke()
    {
        SceneControl.Instance.Continue();
    }
    public void Quit()
    {
        SceneControl.Instance.Quit();
    }
}
