using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public GameObject Asteroid;

    public float SecondsBetweenSpawns;
    private GameObject AsteroidTemp;
    private float currenttime;
    private float UpperLimit, LowerLimit;
    // Start is called before the first frame update
    void Start()
    {
        AsteroidTemp = Asteroid;
        currenttime =SecondsBetweenSpawns;
        UpperLimit = 524.12f;
        LowerLimit = 519.27f;
    }

    // Update is called once per frame
    void Update()
    {
        currenttime -= 1 * Time.deltaTime;
        if(currenttime<=0)
        {
        Instantiate(AsteroidTemp, new Vector3(transform.position.x, Random.Range(UpperLimit,LowerLimit) , 0f),Quaternion.identity);
            currenttime = SecondsBetweenSpawns;
        }
    }
}
