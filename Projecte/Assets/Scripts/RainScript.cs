using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    public int c;
    public GameObject[] centaurides;
    float x;
    float z;
    public float timeToRain;
    float ttr;

    // Start is called before the first frame update
    void Start()
    {
        ttr = timeToRain;
    }

    // Update is called once per frame
    void Update()
    {
        ttr -= Time.deltaTime;
        if (ttr <= 0.0f)
        {               
            x = (int)Random.Range(0.0f, 8.0f) * 10.0f;
            z = (int)Random.Range(0.0f, 4.0f) * 10.0f;
            
            Vector3 initPos = new Vector3(x, 60.0f, z);
            c = (int)Random.Range(0.0f, 2.0f);
            GameObject obj = (GameObject)Instantiate(centaurides[c], initPos, transform.rotation);

            ttr = Random.Range(timeToRain, timeToRain * 2);
        }        
    }
}
