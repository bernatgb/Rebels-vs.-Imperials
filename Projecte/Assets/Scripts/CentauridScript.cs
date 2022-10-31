using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentauridScript : MonoBehaviour
{
    public float velocitat;
    public float ttl;
    public GameObject BigExplosion;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ttl -= Time.deltaTime;
        transform.Translate(0.0f, -velocitat * Time.deltaTime, 0.0f);
        transform.Rotate(0, 1, 0, Space.Self);
        if (ttl <= 0) Destroy(transform.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Shootable" || collision.gameObject.tag == "Shield")
        {
            Instantiate(BigExplosion, transform.position, transform.rotation);
            Destroy(transform.gameObject);
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
    }
}
