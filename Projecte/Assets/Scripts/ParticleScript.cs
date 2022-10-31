using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    float temps;

    // Start is called before the first frame update
    void Start()
    {
        temps = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        temps -= Time.deltaTime;
        if (temps <= 0.0f)
        {
            Destroy(transform.gameObject);
        }
    }
}
