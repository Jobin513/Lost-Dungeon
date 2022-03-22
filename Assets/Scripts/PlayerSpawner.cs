using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public PlayerSpawner Instance;
    public GameObject PlayerPrefab;
    public GameObject Player; // spawned player
    void Awake()
    {
        if (FindObjectOfType<PlayerBehavior>() == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Player = Instantiate(PlayerPrefab);
        }
        else
        {
            Destroy(this);
        }
    }
}
