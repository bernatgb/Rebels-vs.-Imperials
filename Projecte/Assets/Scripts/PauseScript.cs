using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public bool pausa;
    public GameObject menuP; 

    // Start is called before the first frame update
    void Start()
    {
        pausa = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (pausa)
            {
                Reprendre();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Reprendre()
    {
        menuP.SetActive(false);
        Time.timeScale = 1f;
        pausa = false;
    }

    public void Pausar()
    {
        menuP.SetActive(true);
        Time.timeScale = 0f;
        pausa = true;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Sortir()
    {
        Application.Quit();
    }
}
