using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManagerScript : MonoBehaviour
{
    public GameObject Door;
    public GameObject EnemySpawner;
    public GameObject PowerUpsSpawner;
    public BoxCollider2D DoorTrigger;
    private bool tick=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Linker.Score>=10)
        {
            FirstLevelDone();
        }
    }
    public void FirstLevelDone()
    {
        if (!tick)
        {
            EnemySpawner.SetActive(false);
            PowerUpsSpawner.SetActive(false);
        }
        if (Linker.LevelDone == "2")
            {
                if (Door.transform.position.x < -0.3f)
                    Door.transform.Translate(0.05f, 0, 0);
            }
            else
            {

            if (Door.transform.position.x > -7f)
                Door.transform.Translate(-0.05f, 0, 0);
            else
            {
                tick=true;
                DoorTrigger.isTrigger = true;
            }
            }
            

    }
}
