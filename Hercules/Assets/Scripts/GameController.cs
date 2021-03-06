﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour {

    public static GameController control;

    //Player Stats
    [Header("Player Stats")]
    public float playerHealth;
    public float playerSanity;

    //Game Stats
    [Header("Game Stats")]
    public float voidPortalStatus;
    public float plasmaPortalStatus;
    public float twilightPortalStatus;
    public float gameTime;

    //Enemy Stats
    [Header("Enemy Stats")]
    public float goblinHealth;
    public float bossHealth;
    public float voidMonsterHealth;
    public float plasmaMonsterHealth;
    public float twilightMonsterHealth;
    public float goblinCount;
    public float voidCount;
    public float plasmaCount;
    public float twilightCount;
    
    //Statistics
    [Header("Statistics")]
    public float goblinKillCount;
    public float voidKillCount;
    public float plasmaKillCount;
    public float twilightKillCount;

    void Awake () {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
	}

    // Update is called once per frame
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Health: " + playerHealth);
        GUI.Label(new Rect(10, 30, 100, 30), "Sanity: " + playerSanity);
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");

        GameData data = new GameData
        {
            playerHealth = playerHealth,
            playerSanity = playerSanity,
            voidPortalStatus = voidPortalStatus,
            plasmaPortalStatus = plasmaPortalStatus,
            twilightPortalStatus = twilightPortalStatus,
            gameTime = gameTime,
            goblinHealth = goblinHealth,
            bossHealth = bossHealth,
            voidMonsterHealth = voidMonsterHealth,
            plasmaMonsterHealth = plasmaMonsterHealth,
            twilightMonsterHealth = twilightMonsterHealth,
            goblinCount = goblinCount,
            voidCount = voidCount,
            plasmaCount = plasmaCount,
            twilightCount = twilightCount,
            goblinKillCount = goblinKillCount,
            voidKillCount = voidKillCount,
            plasmaKillCount = plasmaKillCount,
            twilightKillCount = twilightKillCount
    };

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();

            playerHealth = data.playerHealth;
            playerSanity = data.playerSanity;
            voidPortalStatus = data.voidPortalStatus;
            plasmaPortalStatus = data.plasmaPortalStatus;
            twilightPortalStatus = data.twilightPortalStatus;
            gameTime = data.gameTime;
            goblinHealth = data.goblinHealth;
            bossHealth = data.bossHealth;
            voidMonsterHealth = data.voidMonsterHealth;
            plasmaMonsterHealth = data.plasmaMonsterHealth;
            twilightMonsterHealth = data.twilightMonsterHealth;
            goblinCount = data.goblinCount;
            voidCount = data.voidCount;
            plasmaCount = data.plasmaCount;
            twilightCount = data.twilightCount;
            goblinKillCount = data.goblinKillCount;
            voidKillCount = data.voidKillCount;
            plasmaKillCount = data.plasmaKillCount;
            twilightKillCount = data.twilightKillCount;
        }
    }
}

[Serializable]
class GameData
{
    //Player Stats
    public float playerHealth;
    public float playerSanity;

    //Game Stats
    public float voidPortalStatus;
    public float plasmaPortalStatus;
    public float twilightPortalStatus;
    public float gameTime;

    //Enemy Stats
    public float goblinHealth;
    public float bossHealth;
    public float voidMonsterHealth;
    public float plasmaMonsterHealth;
    public float twilightMonsterHealth;
    public float goblinCount;
    public float voidCount;
    public float plasmaCount;
    public float twilightCount;

    //Statistics
    public float goblinKillCount;
    public float voidKillCount;
    public float plasmaKillCount;
    public float twilightKillCount;
}