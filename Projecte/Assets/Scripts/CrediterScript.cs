using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrediterScript : MonoBehaviour
{
    private CreditScript creditScript;
    float tempsCredits;
    int escena;

    // Start is called before the first frame update
    void Start()
    {
        creditScript = GameObject.Find("GameLogic").GetComponent<CreditScript>();
        tempsCredits = 4.0f;
        escena = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1, 0, Space.Self);

        tempsCredits -= Time.deltaTime;
        if (tempsCredits <= 0.0f)
        {
            if (escena > 5)
            {
                tempsCredits = 3f;
            }
            else
            {
                tempsCredits = 3f;
            }
            creditScript.credits += 5;
        }
    }
}
