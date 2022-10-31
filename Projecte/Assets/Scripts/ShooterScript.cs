using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public float timeToShoot;
    float tts;
    public bool shooting = false;
    public GameObject shot;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        tts = timeToShoot;

    }

    // Update is called once per frame
    void Update()
    {
        shooting = false;
        RaycastHit hit;
        int layerMask = 1 << 0;
        int layerMask2 = 1 << 8;
        //layerMask = ~layerMask;
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 100, layerMask) || Physics.Raycast(transform.position, Vector3.right, out hit, 100, layerMask2))
        {
            if (hit.transform.tag == "Shootable" || hit.transform.tag == "Enemy")
            {
                shooting = true;
                tts -= Time.deltaTime;
                if (tts <= 0.0f)
                {
                    tts = timeToShoot;
                    Vector3 initTir = new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z);
                    GameObject obj = (GameObject)Instantiate(shot, initTir, transform.rotation);
                    AudioSource.PlayClipAtPoint(sound, transform.position);
                }
            }
        }
    }
}
