using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject EnergyExplosion;
    public Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(30.0f * Time.deltaTime, 0.0f, 0.0f);
        if (Vector3.Distance(initPos, transform.position) > 100)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shootable" || collision.gameObject.tag == "Centaurid" || collision.gameObject.tag == "Enemy")
        {
            Instantiate(EnergyExplosion, transform.position, transform.rotation);
            Destroy(transform.gameObject);
        }
    }
}
