using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapoun : MonoBehaviour
{
    public Transform firepoint;
    public Transform firepoint2;
    public GameObject BulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot() 
    {
        Instantiate(BulletPrefab,firepoint.position,firepoint.rotation);
        Instantiate(BulletPrefab, firepoint2.position, firepoint2.rotation);
    }
    
}
