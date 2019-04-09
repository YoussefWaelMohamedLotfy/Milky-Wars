using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField]
    private float xLimit;
    [SerializeField]
    private float[] xPositions;
    [SerializeField]
    private GameObject[] EnemyPrefabs;
    [SerializeField]
    private Wave[] wave;

    private float CurrentTime;

    List<float> remainingPositions = new List<float>();
    private int waveIndex;
    float xPos = 0;
    int rand;
    

    

    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = 0;
        remainingPositions.AddRange(xPositions);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= Time.deltaTime;
        if(CurrentTime<=0)
        selectWave();
        
    }
    private void SpawnEnemy(float xPos)
    {
            
        int r =Random.Range(0,1);
            GameObject enemyObj = Instantiate(EnemyPrefabs[r], new Vector3(xPos, transform.position.y,0),Quaternion.identity);

        
    }
    private void selectWave()
    {
        remainingPositions = new List<float>();
        remainingPositions.AddRange(xPositions);
        waveIndex = Random.Range(0, wave.Length);
        CurrentTime = wave[waveIndex].delaytime;
        if(wave[waveIndex].SpawnAmount==1)
        {
            xPos = Random.Range(-xLimit, +xLimit);
        }
        else if(wave[waveIndex].SpawnAmount > 1)
        {
            rand = Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            remainingPositions.RemoveAt(rand);
        }
        for (int i = 0; i < wave[waveIndex].SpawnAmount; i++)
        {
            SpawnEnemy(xPos);
            rand = Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            remainingPositions.RemoveAt(rand);
        }
    }
    
}

[System.Serializable]
public class Wave
{
    public float delaytime;
    public float SpawnAmount;
}