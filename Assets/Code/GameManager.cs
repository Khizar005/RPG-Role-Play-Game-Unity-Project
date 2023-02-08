using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [SerializeField] PlayerStats[] playerStats;
    public bool gameMenuOpned, dialogBoxOpened;

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        playerStats = FindObjectsOfType<PlayerStats>();
    }


    void Update()
    {
        if (gameMenuOpned || dialogBoxOpened)
        {
            Player.instance.deactivateMovment = true;
        }
        else
        {
            Player.instance.deactivateMovment = false;
        }
    }
    public PlayerStats[] GetPlayerStats()
    {

        return playerStats;

     }
}
