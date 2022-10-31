using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    // Dades
    private CreditScript creditScript;
    private WaveScript waveScript;
    private EnemyStats enemyStats;
    float tts;
    Vector3 initTir;
    float gt;
    bool adalt;
    bool abaix;
    private TakenScript takenScript;

    // Efectes de morir
    public GameObject BigExplosion;
    public AudioClip sound;
    public bool raro;

    // Efectes de paralització
    bool paralitzat = false;
    float timeParat = 1.0f;

    // Efectes de fantasma
    bool invisible = false;
    float visible = 3.0f; 

    // Start is called before the first frame update
    void Start()
    {
        creditScript = GameObject.Find("GameLogic").GetComponent<CreditScript>();
        waveScript = GameObject.Find("GameLogic").GetComponent<WaveScript>();
        enemyStats = gameObject.GetComponent<EnemyStats>();
        tts = enemyStats.timeToShoot;
        gt = enemyStats.ghostTime;
        adalt = abaix = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (adalt)
        {
            transform.Translate(0.0f, 0.0f, (enemyStats.velocitat * Time.deltaTime) * 3);
            if (transform.position.z % 10 >= 9)
            {
                transform.Translate(0.0f, 0.0f, (10 - transform.position.z % 10));
                adalt = false;
            }
        }
        else if (abaix)
        {
            transform.Translate(0.0f, 0.0f, -(enemyStats.velocitat * Time.deltaTime) * 3);
            if (transform.position.z % 10 <= 1)
            {
                transform.Translate(0.0f, 0.0f, (-transform.position.z % 10));
                abaix = false;
            }
        }
        else
        {
            RaycastHit hit;
            int layerMask = 1 << 9;
            if (Physics.Raycast(transform.position, Vector3.left, out hit, enemyStats.shotRange, layerMask) && (hit.transform.tag == "Player" || hit.transform.tag == "Shield"))
            {
                tts -= Time.deltaTime;
                if (tts <= 0.0f)
                {
                    tts = enemyStats.timeToShoot;
                    initTir = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
                    GameObject obj = (GameObject)Instantiate(enemyStats.shot, initTir, transform.rotation);
                    AudioSource.PlayClipAtPoint(enemyStats.sound, transform.position);
                }
            }
            else if (Physics.Raycast(transform.position, Vector3.left, out hit, 5) && (hit.transform.tag == "Shootable"))
            {
                if (transform.position.z > 25)
                {
                    if (!Physics.Raycast(transform.position, Vector3.back, out hit, 15) && transform.position.z > 5 && !Physics.Raycast(transform.position, new Vector3(1,0,-1), out hit, 25) && !Physics.Raycast(transform.position, new Vector3(-1, 0, -2), out hit, 25))
                    {
                        abaix = true;
                    }
                    else if (!Physics.Raycast(transform.position, Vector3.forward, out hit, 15) && transform.position.z < 35 && !Physics.Raycast(transform.position, new Vector3(1, 0, 1), out hit, 25) && !Physics.Raycast(transform.position, new Vector3(-1, 0, 2), out hit, 25))
                    {
                        adalt = true;
                    }
                }
                else
                {
                    if (!Physics.Raycast(transform.position, Vector3.forward, out hit, 15) && transform.position.z < 35 && !Physics.Raycast(transform.position, new Vector3(1, 0, 1), out hit, 25) && !Physics.Raycast(transform.position, new Vector3(-1, 0, 2), out hit, 25))
                    {
                        adalt = true;
                    }
                    else if (!Physics.Raycast(transform.position, Vector3.back, out hit, 15) && transform.position.z > 5 && !Physics.Raycast(transform.position, new Vector3(1, 0, -1), out hit, 25) && !Physics.Raycast(transform.position, new Vector3(-1, 0, -2), out hit, 25))
                    {
                        abaix = true;
                    }
                }
            }
            else if (paralitzat)
            {
                timeParat -= Time.deltaTime;
                if (timeParat <= 0.0f)
                {
                    timeParat = 1.0f;
                    paralitzat = false;
                }
            }
            else
            {
                if (invisible)
                {
                    transform.Translate(-((enemyStats.velocitat - 1) * Time.deltaTime), 0.0f, 0.0f);
                }
                else
                {
                    transform.Translate(-(enemyStats.velocitat * Time.deltaTime), 0.0f, 0.0f);
                }
            }

            if (transform.position.x < -10.0f)  //Derrota
            {
                SceneManager.LoadScene("Lose");
            }

            if (enemyStats.fantasma)
            {
                if (!invisible && transform.position.x > 5.0f)
                {
                    visible -= Time.deltaTime;
                    if (visible <= 0.0f)
                    {
                        invisible = true;
                        transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                        transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
                        transform.GetComponent<SphereCollider>().enabled = false;
                        visible = 3.0f;
                    }
                }
                if (invisible)
                {
                    gt -= Time.deltaTime;
                    if (gt <= 0.0f)
                    {
                        invisible = false;
                        transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                        transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
                        transform.GetComponent<SphereCollider>().enabled = true;
                        gt = enemyStats.ghostTime;
                    }
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NormalShot")
        {
            if (raro) { }
            else
            {
                if (enemyStats.vida > 0) --enemyStats.vida;
                else
                {
                    Instantiate(BigExplosion, transform.position, transform.rotation);
                    Destroy(transform.gameObject);
                    AudioSource.PlayClipAtPoint(sound, transform.position);
                    creditScript.credits += enemyStats.punts;
                    ++waveScript.morts;
                }
            }
        }

        if (collision.gameObject.tag == "ParalShot")
        {
            paralitzat = true;
        }

        if (collision.gameObject.tag == "BombShot")
        {

            if (enemyStats.vida > 3) enemyStats.vida -= 4;
            else
            {
                Instantiate(BigExplosion, transform.position, transform.rotation);
                Destroy(transform.gameObject);
                AudioSource.PlayClipAtPoint(sound, transform.position);
                creditScript.credits += enemyStats.punts;
                ++waveScript.morts;
            }
        }

        if (collision.gameObject.tag == "Centaurid")
        {
            Instantiate(BigExplosion, transform.position, transform.rotation);
            Destroy(transform.gameObject);
            AudioSource.PlayClipAtPoint(sound, transform.position);
            ++waveScript.morts;
        }

        if (collision.gameObject.tag == "Mine")
        {
            if (enemyStats.vida > 15) enemyStats.vida -= 15;
            else
            {
                Instantiate(BigExplosion, transform.position, transform.rotation);
                Destroy(transform.gameObject);
                AudioSource.PlayClipAtPoint(sound, transform.position);
                creditScript.credits += enemyStats.punts;
                ++waveScript.morts;
            }
        }


    }

    /*void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Mine")
        {
            if (enemyStats.vida > 10) enemyStats.vida -= 10;
            else
            {
                Instantiate(BigExplosion, transform.position, transform.rotation);
                Destroy(transform.gameObject);
                AudioSource.PlayClipAtPoint(sound, transform.position);
                creditScript.credits += enemyStats.punts;
                ++waveScript.morts;
            }
        }
    }*/
}
