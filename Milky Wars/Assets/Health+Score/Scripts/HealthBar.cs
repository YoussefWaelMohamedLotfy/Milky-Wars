using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HealthBar : MonoBehaviour {
    string Path;
    public Text GameOver;
    private float sizeNormalized = 1;
    public float Damage;
    private Transform bar;
    bool  Check_Life  = true ;
	private void Awake () {
        CreateFile();
        bar = transform.Find("Bar");
         
	}

     void Update ()
    {
        if (Linker.GotAttacked)
        {
            SetSize();
            Linker.GotAttacked = false;
        }
       
     }

     public void SetSize(   )
    {
        if(Linker.GotAttacked)
        {

             sizeNormalized = sizeNormalized - (Damage/100) ;           
             bar.localScale = new Vector3(sizeNormalized, 1f);
             if (sizeNormalized < 0)
             {
                 Check_Life = false;
                sizeNormalized = 0;
                GameOver.text = "Game Over";
                File.AppendAllText(Path, Linker.UserName +"*"+Linker.Score+"\n");
                bar.localScale = new Vector3(sizeNormalized, 1f);
             }
        }
     }

    void CreateFile()
    {
        Path = Application.dataPath + "/Score.txt";
        if (!File.Exists(Path))
        {
            File.WriteAllText(Path,"");
        }
    }


}
