using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public List<IEndGame> endgame = new List<IEndGame>();
    public GameObject SaveLog;
    public GameObject GameOverUI;

    CharacterManager playerstate;
    PlayerControl playercontrol;
    bool playercontrolplan = false;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    //添加ENDGAME接口
    public void AddObserver(IEndGame observer)
    {
        endgame.Add(observer);
    }
    public void RemoveObserver(IEndGame observer)
    {
        if (endgame.Contains(observer))
            endgame.Remove(observer);
    }

    /*
    public void UIRehister(GameObject ui)
    {
        GameOverUI = ui;
    }
    */
    public void PlayerRegister(CharacterManager state, PlayerControl player)
    {
        playerstate = state;
        playercontrol = player;
    }
    //保存玩家数值，位置，背包内容，目前Scene
    public void PlayerSave()
    {
        SaveManager.Instance.SaveScene(SceneManager.GetActiveScene().name);
        SaveManager.Instance.SavePlayerState(playerstate.characterstate, playerstate.name);
        SaveManager.Instance.SavePosition(playerstate.transform.position, playerstate.gameObject.name);
        SaveManager.Instance.SaveInventory(InventoryManager.Instance.InventoryDate, "Inventory");
    }
    //加载玩家数值，位置，背包内容，目前Scene
    //切换武器
    public void PlayerLoad(bool haspos)
    {
        SaveManager.Instance.LoadPlayerState(playerstate.characterstate, playerstate.name);
        if (haspos)
            playerstate.transform.position = SaveManager.Instance.LoadPosition(playerstate.gameObject.name);
        var agent = playerstate.transform.GetComponent<NavMeshAgent>();
        agent.enabled = false;
        agent.enabled = true;
        playerstate.PlayerUIUpdate();
        SaveManager.Instance.LoadInventory(InventoryManager.Instance.InventoryDate, "Inventory");
        ChangerPlayerWeapon(InventoryManager.Instance.GetWeaponDate());
        playercontrol.movebymouse = playercontrolplan;
    }
    public void GameOver()
    {
        foreach (IEndGame observer in endgame)
        {
            observer.EndNotify();
        }
        Invoke("OpenEndGameUI", 2f);
    }

    public void EnemyDead(float exp)
    {
        playerstate.GetExp(exp);
    }

    void OpenEndGameUI()
    {
        GameOverUI.SetActive(true);
    }
    public void CloseEndGameUI()
    {
        GameOverUI.SetActive(false);
    }

    public void PlayerHealthReply(float h)
    {
        playerstate.CurrentHealth = Mathf.Min(playerstate.CurrentHealth + h, playerstate.MaxHealth);
        playerstate.RefreshPlayerUI();
    }

    //更改player武器（prefab,anim control）
    public void ChangerPlayerWeapon(Item_SO weapon)
    {
        playercontrol.ChangeWeapon(weapon.wDate.lweapon, weapon.wDate.rweapon, weapon.wDate.Wanim);
        playerstate.attack = Instantiate(weapon.wDate.WeaponAttack);
    }
    public void ChangePlayerControl(bool f)
    {
        playercontrolplan = f;
        if (playercontrol != null)
            playercontrol.movebymouse = playercontrolplan;

    }

    //public void EnemyAwake()
    //{
    //    Debug.Log("e1");
    //    var enemys = GameObject.FindObjectsOfType<EnemyControl>();
    //    Debug.Log(enemys.Length);
    //    foreach (var enemy in enemys)
    //    {
    //        Debug.Log("e");
    //        enemy.gameObject.SetActive(true);
    //    }
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerSave();
            Debug.Log("Save");
            LogSave();
        }

        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    PlayerLoad();
        //}
    }

    void LogSave()
    {
        SaveLog.SetActive(true);
        Invoke("CloseLog", 3f);
    }

    void CloseLog()
    {
        SaveLog.SetActive(false);
    }
}
