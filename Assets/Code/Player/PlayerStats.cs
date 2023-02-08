using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;


    public string playerName;
     
    public int[] xpForNextLevel;
    public Sprite characterImage;

    public int maxLevel =50, playerLevel =1, currentXP, baseLevelXP, maxHp=100, currentHp,maxMana=30, currentMana, dexterity, Defence;

    void Start()
    {
        instance = this;
        xpForNextLevel = new int[maxLevel];
        for(int i =1; i < xpForNextLevel.Length; i++)
        {
            xpForNextLevel[i] = Convert.ToInt32(0.02f *i *i * i + 3.06f* i *i + 105.6f*i);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            AddXP(100);
        }
    }

    public void AddXP(int amount)
    {
        currentXP += amount;
        if(currentXP > xpForNextLevel[playerLevel])
        {
            currentXP -= xpForNextLevel[playerLevel];
            playerLevel++;

            if(playerLevel % 2 == 0)
            {
                dexterity++;
            }
            else
            {
                Defence++;
            }
            maxHp = Mathf.FloorToInt(maxHp * 1.06f);
            currentHp += maxHp;

            currentMana = Mathf.FloorToInt(maxMana * 1.16f);
            currentMana += maxMana;
        }
    }

    public void AddHP(int amoutHpToAdd)
    {
        currentHp += amoutHpToAdd;
        if(currentHp > maxHp)
        {
            currentHp = maxHp;
        }

    }
    public void AddMana(int amoutManaToAdd)
    {
        currentHp += amoutManaToAdd;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }

    }
}
