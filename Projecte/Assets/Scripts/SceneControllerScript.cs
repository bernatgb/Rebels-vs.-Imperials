using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControllerScript : MonoBehaviour
{
    int escena;

    // Start is called before the first frame update
    void Start()
    {
        escena = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M)) 
        {
            SceneManager.LoadScene("Menu");
        }
        else if (Input.GetKey(KeyCode.I))
        {
            SceneManager.LoadScene("Intro1");
        }
        else if (Input.GetKey(KeyCode.U))
        {
            SceneManager.LoadScene("Intro2");
        }
        else if (Input.GetKey(KeyCode.W))
        {
            SceneManager.LoadScene("Win");
        }
        else if (Input.GetKey(KeyCode.L))
        {
            SceneManager.LoadScene("Lose");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ++escena;
            SceneManager.LoadScene(escena);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            --escena;
            SceneManager.LoadScene(escena);
        }
    }
}
