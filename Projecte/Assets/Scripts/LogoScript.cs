using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScript : MonoBehaviour
{
    float velocitat;
    float desapareix;

    // Start is called before the first frame update
    void Start()
    {
        velocitat = 40.0f;
        desapareix = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.0f, -(velocitat * Time.deltaTime), 0.0f);
        if (transform.position.z >= 500.0f)
        {
            desapareix -= Time.deltaTime;
            this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, desapareix);
        }
    }
}
