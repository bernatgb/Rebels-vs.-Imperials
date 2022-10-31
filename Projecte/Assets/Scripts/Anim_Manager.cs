using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Manager : MonoBehaviour
{

    Animator animator;
    public bool s;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        s = false;
        RaycastHit hit;
        int layerMask = 1 << 9;
        layerMask = ~layerMask;
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 100, layerMask))
        {
            if (hit.transform.tag == "Shootable")
            {
                s = true;

            }
        }
        animator.SetBool("Shoot", s); 
    }


}
