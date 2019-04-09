using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAsteroid : MonoBehaviour
{
    public AudioSource Sound;
    // Start is called before the first frame update
    void Start()
    {
        Sound.loop = false;
        Sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1f,0f,0f));
    }
}
