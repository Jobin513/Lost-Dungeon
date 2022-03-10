using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField] private int targetSceneNum;
    [SerializeField] public int id;
    [SerializeField] public int targetid;
    [SerializeField] public Transform tran;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            SceneManager.LoadScene(targetSceneNum);
            DontDestroyOnLoad(collision);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerBehavior>().FindNewLocation(this);
            Debug.Log("trigger enter end");
        }
    }
}
