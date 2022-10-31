using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroNScript : MonoBehaviour
{
    public float temps;
    int escena;

    // Start is called before the first frame update
    void Start()
    {
        escena = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        temps -= Time.deltaTime;
        if (temps <= 0.0f)
        {
            SceneManager.LoadScene(escena + 1);
        }
    }
}
