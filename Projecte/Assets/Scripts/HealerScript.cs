using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerScript : MonoBehaviour
{
    private HealthScript healthScript;
    GameObject nau;
    public float timeToHeal;
    float tth;
    public GameObject shot;
    public GameObject heal;

    // Start is called before the first frame update
    void Start()
    {
        tth = timeToHeal;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 15))
        {
            if (hit.transform.tag == "Player")
            {
                nau = hit.transform.gameObject;
                healthScript = nau.GetComponent<HealthScript>();

                tth -= Time.deltaTime;
                if (tth <= 0.0f && healthScript.maxVida > healthScript.vida)
                {
                    Debug.Log("entra");
                    Vector3 initTir = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5.0f);
                    Quaternion rotTir = Quaternion.LookRotation(Vector3.left, Vector3.up);
                    GameObject obj = (GameObject)Instantiate(shot, initTir, rotTir);
                    tth = timeToHeal;
                    Debug.Log(tth);
                    ++healthScript.vida;
                }
            }
        }

        if (Physics.Raycast(transform.position, Vector3.back, out hit, 15))
        {
            if (hit.transform.tag == "Player")
            {
                nau = hit.transform.gameObject;
                healthScript = nau.GetComponent<HealthScript>();

                tth -= Time.deltaTime;
                if (tth <= 0.0f && healthScript.maxVida > healthScript.vida)
                {
                    Vector3 initTir = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.0f);
                    Quaternion rotTir = Quaternion.LookRotation(Vector3.right, Vector3.up);
                    GameObject obj = (GameObject)Instantiate(shot, initTir, rotTir);
                    tth = timeToHeal;
                    ++healthScript.vida;
                }
            }
        }
    }
}
