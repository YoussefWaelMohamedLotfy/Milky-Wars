using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAnimation : MonoBehaviour
{
    public float RotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, RotationSpeed);       
    }
}
