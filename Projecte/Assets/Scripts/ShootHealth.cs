using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHealth : MonoBehaviour
{
    public GameObject heal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(20.0f * Time.deltaTime, 0.0f, 0.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Shield")
        {
            Instantiate(heal, transform.position, transform.rotation);
            Destroy(transform.gameObject);
        }
    }
}
