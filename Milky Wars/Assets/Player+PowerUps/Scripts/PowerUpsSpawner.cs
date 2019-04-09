using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsSpawner : MonoBehaviour
{
    public GameObject[] EnemyPrefabs = new GameObject[4];
    
    public int SpawningDelay;
    private float startingTime;
    public float UpperLimit, LowerLimit, RightLimit, LeftLimit;
    // Start is called before the first frame update
    void Start()
    {
        startingTime = SpawningDelay;
    }
        
    // Update is called once per frame
    void Update()
    {

        if (startingTime < 0)
        {
            Instantiate(EnemyPrefabs[Random.Range(0,4)], new Vector3(Random.Range(RightLimit, LeftLimit), Random.Range(UpperLimit, LowerLimit), 0), Quaternion.identity);
            startingTime = SpawningDelay;
        }
        else
            startingTime -= 1 * Time.deltaTime;

    }
}
