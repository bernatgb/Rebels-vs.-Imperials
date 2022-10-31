using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject[] asteroides;
    public float temps;
    float t;

    // Start is called before the first frame update
    void Start()
    {
        t = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (asteroides.Length > 0)
        {
            t -= Time.deltaTime;
            if (t <= 0.0f)
            {
                int asteroide = (int)Random.Range(0.0f, asteroides.Length);

                float randY = Random.Range(0.0f, 6.0f);
                float randZ = Random.Range(10.0f, 15.0f);

                Vector3 pos = new Vector3(-(5.0f + randZ), randY, randZ);
                GameObject obj = (GameObject)Instantiate(asteroides[asteroide], pos, transform.rotation);

                t = temps;
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            for (int i = 3; i <= 8; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    public void ClicarPlay()
    {
        SceneManager.LoadScene("Intro1");
    }

    public void ClicarInstr()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        for (int i = 3; i <= 8; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ClicarShips()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        for (int i = 3; i <= 8; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ClicarCredits()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        for (int i = 3; i <= 8; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ClicarAdeu()
    {
        Application.Quit();
    }
}
