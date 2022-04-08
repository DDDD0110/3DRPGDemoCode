using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    //状态数值保存
    public void SavePlayerState(CharacterState_SO playstate,string playername)
    {
        Save(playstate, playername);
    }

    public void LoadPlayerState(CharacterState_SO playstate, string playername)
    {
        Load(playstate, playername);
    }

    //背包数据保存
    public void SaveInventory(Inventory_SO inventory, string inventorykey)
    {
        Save(inventory, inventorykey);
    }
    public void LoadInventory(Inventory_SO inventory, string inventorykey)
    {
        Load(inventory, inventorykey);
    }
    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }

    //vector3 pos保存

    public void SavePosition(Vector3 pos,string key)
    {
        float x = pos.x;
        float y = pos.y;
        float z = pos.z;
        var keyx = "key" + "x";
        var keyy = "key" + "y";
        var keyz = "key" + "z";
        PlayerPrefs.SetFloat(keyx, x);
        PlayerPrefs.SetFloat(keyy, y);
        PlayerPrefs.SetFloat(keyz, z);
        PlayerPrefs.Save();

    }

    public Vector3 LoadPosition(string key)
    {
        var keyx = "key" + "x";
        var keyy = "key" + "y";
        var keyz = "key" + "z";
        if (PlayerPrefs.HasKey(keyx))
        {
            var x = PlayerPrefs.GetFloat(keyx);
            var y = PlayerPrefs.GetFloat(keyy);
            var z = PlayerPrefs.GetFloat(keyz);
            return new Vector3(x, y, z);
        }
        return Vector3.zero;
    }

    public void SaveScene(string scenename)
    {
        PlayerPrefs.SetString("sceneName",scenename);
        PlayerPrefs.Save();
    }

    public string LoadScene()
    {
        if (PlayerPrefs.HasKey("sceneName"))
        {
            return PlayerPrefs.GetString("sceneName");
        }
        return null;
    }


    //是否有储存数据，若有Scene的数据则有其他数据
    public bool HasDate()
    {
        if (PlayerPrefs.HasKey("sceneName"))
            return true;
        else
            return false;
    }

    private void Save(object date,string key)
    {
        var jsondate = JsonUtility.ToJson(date);
        PlayerPrefs.SetString(key, jsondate);
        PlayerPrefs.Save();
    }
    private void Load(object date, string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), date);
        }
            
    }



}
