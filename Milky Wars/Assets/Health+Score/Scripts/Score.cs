using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Score  : MonoBehaviour {
    public Text ScoreText;

    void ScoreCounter()
    {
        ScoreText.text = Linker.Score.ToString();
    }

	void Update () {
    

            ScoreCounter();  
        
        
    }
}
