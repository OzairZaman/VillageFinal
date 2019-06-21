using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    [Header("Player Stats")]

    public string[] stats;
    public int[] statDats;
    public string playerName;
    public int level;
    public float maxHp, maxStam, maxMana, maxExp;
    public float curHp, curStam, curMana, curExp;

    [Header("Game Reference")]
    public Vector3 savePos;

    [Header("HP bar")]
    public Slider hpBar;

    [Header("Other Bars")]
    public Slider stamBar, manaBar, expBar;

    void Start()
    {
        Load();
    }


    public void Save()
    {
        Debug.Log("We Are in Save");
        savePos = this.transform.position;
        SaveToBinary.SaveData(this);
    }


    public void Load()
    {
        DataToSave data = SaveToBinary.LoadData(this); // parameter is being wasted
        if (data != null)
        {
            Debug.Log("We Loaded");
        }
        else
        {
            Debug.Log("We fucked up load!");
            return;
        }
        playerName = data.playerName;
        level = data.level;
        maxHp = data.maxHP;
        maxMana = data.maxMana;
        maxStam = data.maxStam;
        curHp = data.curHP;
        curMana = data.curMana;
        curStam = data.curStam;

        savePos.x = data.x;
        savePos.y = data.y;
        savePos.z = data.z;

        //this.transform.position = savePos;


    }


    void Update()
    {
        savePos = this.transform.position;
        hpBar.value = Mathf.Clamp01(curHp / maxHp);

        manaBar.value = Mathf.Clamp01(curMana / maxMana);
        stamBar.value = Mathf.Clamp01(curStam / maxStam);
    }
}
