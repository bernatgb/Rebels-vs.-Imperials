using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakenScript : MonoBehaviour
{
    public bool ocupada;
    public GameObject aliat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //int layerMask = 1 << 9;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, 10))
        {
            ocupada = true;
        }
        else
        {
            ocupada = false;
        }
    }
}
