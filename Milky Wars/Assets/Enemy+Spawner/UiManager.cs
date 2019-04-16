using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;



public class UiManager : MonoBehaviour
{
    string Path;
    public Slider healthSlider;
    public GameObject GameOver;
    public GameObject PlayAgainB;
    public GameObject MainMenuB;
    public GameObject leftJoystick;
    public GameObject rightJoystick;

    // Start is called before the first frame update
    void Start()
    {
        CreateFile();
    }

    // Update is called once per frame
    void Update()
    {

        UpdateHealthSlider();
    }

    public void UpdateHealthSlider()
    {
        healthSlider.value = Linker.Health;
        if(Linker.Health<1)
        {
            GameOver.SetActive(true);
            PlayAgainB.SetActive(true);
            MainMenuB.SetActive(true);
            leftJoystick.SetActive(false);
            rightJoystick.SetActive(false);
            File.AppendAllText(Path, Linker.UserName + "*" + Linker.Score + "\n");
            Linker.Health = 100;
            Linker.Score = 0;
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
        
    }
    void CreateFile()
    {
        Path = Application.dataPath + "/Score.txt";
        if (!File.Exists(Path))
        {
            File.WriteAllText(Path, "");
        }
    }
}
