using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borderScript : MonoBehaviour
{
    public BoxCollider2D DownTrigger;
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
        if (other.tag == "Player")
            DownTrigger.isTrigger = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            DownTrigger.isTrigger = false;
    }
}
