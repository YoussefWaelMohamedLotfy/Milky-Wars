using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera camera;
    private bool check1=false, check2=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Linker.LevelDone=="1")
        {
            if (this.transform.position.y < 4.7f)
            {
                this.transform.Translate(0, 0.5f, 0);
            }
            else
            {
                check1 = true;
            }

            if (camera.orthographicSize < 10f)
                camera.orthographicSize += 1f;

            else
            {
                check2 = true;
            }

            if(check1&&check2)
            {
                Linker.LevelDone = "2";
            }
        }
        
    }
}
