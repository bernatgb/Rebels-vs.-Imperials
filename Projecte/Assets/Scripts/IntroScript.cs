using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    float temps;

    // BlueText
    public Text text;
    float desapareix;

    // Logo
    public GameObject logo;
    Vector3 initLogo;
    bool logoFet;

    // Start is called before the first frame update
    void Start()
    {
        temps = 0.0f;
        desapareix = 1.5f;
        initLogo = new Vector3(0.0f, 0.0f, 50.0f);
        logoFet = false;
    }

    // Update is called once per frame
    void Update()
    {
        temps += Time.deltaTime;

        if (temps >= 3.5f)  // BlueText
        {
            desapareix -= Time.deltaTime;
            text.color = new Color(text.color.r, text.color.g, text.color.b, (1.0f / 1.5f) * desapareix);
        }

        if (temps >= 7.1f && !logoFet)
        {
            GameObject obj = (GameObject)Instantiate(logo, initLogo, transform.rotation);
            obj.transform.Rotate(90, 180, 0, Space.World);
            logoFet = true;
        }

        if (temps >= 60.0f)
        {
            int escena = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(escena + 1);
        }
    }
}
