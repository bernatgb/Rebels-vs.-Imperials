using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    public GameObject BigExplosion;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1, 0, Space.Self);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shootable" || collision.gameObject.tag == "Enemy")
        {
            Instantiate(BigExplosion, transform.position, transform.rotation);
            Destroy(transform.gameObject);
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
    }
}
