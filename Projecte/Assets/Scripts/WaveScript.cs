using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveScript : MonoBehaviour
{
    public GameObject[] enemics;
    public GameObject shield;
    public int numEnemics;
    public float maxTimeToSpawn;
    public float minTimeToSpawn;
    float timeToSpawn;
    public int morts;
    int nE;
    float ultimP;
    float ultimE;

    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = 15.0f;
        nE = numEnemics;
        ultimP = -1;
        ultimE = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (numEnemics > 0)
        {
            timeToSpawn -= Time.deltaTime;
            if (timeToSpawn <= 0)
            {
                timeToSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);

                int randZ = ((int)Random.Range(0.0f, 4.0f)) * 10;
                while (ultimP == randZ)
                {
                    randZ = ((int)Random.Range(0.0f, 4.0f)) * 10;
                }
                ultimP = randZ;
                
                Vector3 pos = new Vector3(80.0f, 5.0f, randZ); // -2.0f per l'efecte visual

                int enemic = (int)Random.Range(0.0f, enemics.Length);
                while (ultimE == enemic)
                {
                    enemic = (int)Random.Range(0.0f, enemics.Length);
                }
                ultimE = enemic;

                GameObject obj = (GameObject)Instantiate(enemics[enemic], pos, transform.rotation);


                --numEnemics;
            }
        }
        if (morts == nE)
        {
            int escena = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(escena + 1);
        }
    }
}
