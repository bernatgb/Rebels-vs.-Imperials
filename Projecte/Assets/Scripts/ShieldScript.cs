using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public int vida;
    GameObject casella;
    public float velocitat;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-velocitat * Time.deltaTime, 0.0f, 0.0f);
        //transform.Rotate(0, 1, 0, Space.Self);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyShot")
        {
            if (vida > 0) --vida;
            else
            {
                Destroy(transform.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Centaurid" || collision.gameObject.tag == "Mine")
        {
            Destroy(transform.gameObject);
        }
        else if (collision.gameObject.tag == "BombShot" || collision.gameObject.tag == "NormalShot")
        {
            if (vida > 0) --vida;
            else
            {
                Destroy(transform.gameObject);
            }
        }
    }
}