using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject enemySpawner2;
    public GameObject powerUpsSpawner2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Player")
        {
            enemySpawner2.SetActive(true);
            powerUpsSpawner2.SetActive(true);
            Linker.LevelDone = "1";
            
        }
    }
}
