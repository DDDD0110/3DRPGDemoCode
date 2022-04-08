using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : Singleton<SceneControl>
{
    public GameObject playerPrefab;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    public void TransitionToDestination(string sceneName, int portalIndex)
    {
        GameManager.Instance.PlayerSave();
        StartCoroutine(Transition(sceneName, portalIndex));
    }

    IEnumerator Transition(string sceneName, int portalIndex)
    {
        
        yield return SceneManager.LoadSceneAsync(sceneName);
        yield return Instantiate(playerPrefab,GetDestinationPos(portalIndex).position,GetDestinationPos(portalIndex).rotation);
        GameManager.Instance.PlayerLoad(false);
        //GameManager.Instance.EnemyAwake();
        yield break;
    }

    Transform GetDestinationPos(int portalIndex)
    {
        Portal[] des = FindObjectsOfType<Portal>();
        foreach (Portal temp in des)
        {
            if (temp.PortalIndex == portalIndex)
                return temp.transform;
        }
        return null;
    }

    public void NewGame()
    {
        SaveManager.Instance.DeleteSave();
        StartCoroutine(TransitionToFirstLevel());
    }
    public void Continue()
    {
        if (SaveManager.Instance.HasDate())
        {
            StartCoroutine(IContinue(SaveManager.Instance.LoadScene()));
        }
        else
            Debug.Log("NO");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ReturnMenu()
    {
        if (SceneManager.GetActiveScene().name != "MENU")
        {
            InventoryManager.Instance.CloseInventory();
            StartCoroutine(TransitionMenu());
        }
            
    }
    IEnumerator TransitionToFirstLevel()
    {
        yield return SceneManager.LoadSceneAsync(1,LoadSceneMode.Single);
        var startpoint = GameObject.FindWithTag("StartPoint").transform;
        yield return Instantiate(playerPrefab, startpoint.position, startpoint.rotation);
        InventoryManager.Instance.InitializeInventory();
        //GameManager.Instance.EnemyAwake();
        yield break;
    }
    IEnumerator TransitionMenu()
    {
        yield return SceneManager.LoadSceneAsync("MENU",LoadSceneMode.Single);
        yield break;
    }

    IEnumerator IContinue(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Single);
        var startpoint = GameObject.FindWithTag("StartPoint").transform;
        yield return Instantiate(playerPrefab, startpoint.position, startpoint.rotation);
        GameManager.Instance.PlayerLoad(true);
        //GameManager.Instance.EnemyAwake();
        yield break;
    }

    public string RetuenSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

}
