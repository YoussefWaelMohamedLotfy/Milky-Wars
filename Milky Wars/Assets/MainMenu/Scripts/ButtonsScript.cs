using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ButtonsScript : MonoBehaviour
{
    
    string Path;
    public Text Play, H2P, Quit,GameName,ScoreBoardData, ScoreBoardData2;
    public GameObject MainMenu, InputName, ScoreBoard, H2Play, Controls, Instructions;
    public InputField IF;
    private float Speed;
    public Scrollbar SB1,SB2;
    public bool check = false;
    public bool Scroll = false;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 0.0005f;
        Path = Application.dataPath + "/Score.txt";
    }

    // Update is called once per frame
    void Update()
    {
        if (Scroll)
        {
            SB2.value -= Speed;
            SB1.value = SB2.value;
        }
        if (SB1.value == 0)
            Speed *= -1;
        if (SB1.value == 1)
            Speed *= -1;
                    

    }

  public  void play()
    {
        MainMenu.SetActive(false);
        InputName.SetActive(true);
    }
    public void H2play()
    {
        MainMenu.SetActive(false);
        H2Play.SetActive(true);
    }
    public void Next()
    {
        Instructions.SetActive(false);
        Controls.SetActive(true);
    }
    public void scoreBoard()
    {
        
        MainMenu.SetActive(false);
        ScoreBoard.SetActive(true);
        Linker.Scores = File.ReadAllLines(Path);
        for(int b=0;b<Linker.Scores.Length;b++)
        {
            Pair<string, int> temp = new Pair<string, int>();
            temp.First = "";
            temp.Second = 0;
            Linker.NamesAndScores.Add(temp);
        }
       
        for (int i = 0; i < Linker.Scores.Length; i++)
        {
            int Index = 0;
            string temp = "";
            for(int j=0;j<Linker.Scores[i].Length;j++)
            {
                if (Linker.Scores[i][j] == '*')
                {
                    Index = j + 1;
                    break;
                }
                else
                {
                    Linker.NamesAndScores[i].First += Linker.Scores[i][j];
                }
            }

            for(int z=Index;z<Linker.Scores[i].Length;z++)
            {
                temp += Linker.Scores[i][z];
            }
            for (int z = Index; z < Linker.Scores[i].Length; z++)
            {
                Linker.NamesAndScores[i].Second = int.Parse(temp);
            }
        }
        Linker.NamesAndScores.Sort((s1, s2) => s2.Second.CompareTo(s1.Second));
        for (int i=0;i<Linker.NamesAndScores.Count;i++)
        {
            ScoreBoardData.text += Linker.NamesAndScores[i].First + "\n";
        }
        for (int i = 0; i < Linker.NamesAndScores.Count; i++)
        {
            ScoreBoardData2.text += Linker.NamesAndScores[i].Second + "\n";
        }

        Scroll = true;
    }
    public void Back()
    {
        ScoreBoardData.text = "";
        ScoreBoardData2.text = "";
        Linker.NamesAndScores.Clear();
        MainMenu.SetActive(true);
        ScoreBoard.SetActive(false);
        H2Play.SetActive(false);
        Scroll = false;
        SB1.value = 1;
        SB2.value = 1;
    }
    public void go()
    {
        Linker.UserName = IF.text;
        SceneManager.LoadScene(1);
    }
}
