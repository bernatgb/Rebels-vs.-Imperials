using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int vida;
    public int maxVida;
    public GameObject BigExplosion;
    public AudioClip sound;
    GameObject casella;
    private TakenScript takenScript;

    // Start is called before the first frame update
    void Start()
    {
        /*
        RaycastHit hit;
        int layerMask = 1 << 9;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100, layerMask)) //, LayerMask.NameToLayer("Ground")
        {
            casella = hit.transform.gameObject;
        }
        takenScript = casella.GetComponent<TakenScript>();
        */
        maxVida = vida;
    }

    // Update is called once per frame
    void Update()
    {

    }
        

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyShot")
        {
            if (vida > 0) --vida;
            else
            {
                Instantiate(BigExplosion, transform.position, transform.rotation);
                Destroy(transform.gameObject);
                AudioSource.PlayClipAtPoint(sound, transform.position);
                //takenScript.ocupada = false;
            }
        }
        else if (collision.gameObject.tag == "Centaurid")
        {
            Instantiate(BigExplosion, transform.position, transform.rotation);
            Destroy(transform.gameObject);
            AudioSource.PlayClipAtPoint(sound, transform.position);
            //takenScript.ocupada = false;
        }
    }
}
