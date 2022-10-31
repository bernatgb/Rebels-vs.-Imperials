using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    float temps;
    float velocitat;
    float desapareix;

    // Start is called before the first frame update
    void Start()
    {
        temps = 7.0f;
        velocitat = 20.0f;
        desapareix = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        temps -= Time.deltaTime;
        if (temps <= 0.0f)
        {
            Vector3 pos = transform.position;
            Vector3 up = transform.TransformDirection(0.0f, 1.0f, 0.0f);
            pos += up * velocitat * Time.deltaTime;
            transform.position = pos;
        }

        if (transform.position.z >= 600.0f)
        {
            desapareix -= Time.deltaTime;
            this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, desapareix);
        }
    }
}
