using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyScript : MonoBehaviour
{
    public int aliat;
    public GameObject[] aliats;
    public float[] preus;
    public bool triat;
    public GameObject casella;
    private CreditScript creditScript;
    

    // Start is called before the first frame update
    void Start()
    {
        aliat = -1;
        creditScript = GameObject.Find("GameLogic").GetComponent<CreditScript>();
        triat = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            aliat = 0;
            triat = true;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            aliat = 1;
            triat = true;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            aliat = 2;
            triat = true;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            aliat = 3;
            triat = true;
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            aliat = 4;
            triat = true;
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            aliat = 5;
            triat = true;
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            aliat = 6;
            triat = true;
        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            aliat = 7;
            triat = true;
        }
        if (Input.GetMouseButtonDown(0) && triat)
        {
            triat = false;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, 1 << LayerMask.NameToLayer("Respawn")))
            {
                
                if (hit.transform.tag == "Respawn")
                {
                    casella = hit.transform.gameObject;
                }
                else
                {
                    casella = null;
                }
            }
            
            TakenScript takenScript = casella.GetComponent<TakenScript>();
            if (!takenScript.ocupada && creditScript.credits >= preus[aliat] && aliat != 7)
            {
                creditScript.credits -= preus[aliat];
                Vector3 pos = new Vector3(casella.transform.position.x, 5.0f, casella.transform.position.z);
                takenScript.aliat = (GameObject)Instantiate(aliats[aliat], pos, Quaternion.identity);
                takenScript.ocupada = true;
            }
            else if (aliat == 7 && takenScript.ocupada && creditScript.credits >= preus[aliat])
            {
                creditScript.credits -= preus[aliat];
                Vector3 pos = new Vector3(casella.transform.position.x, 5.0f, casella.transform.position.z);
                takenScript.aliat = (GameObject)Instantiate(aliats[aliat], pos, Quaternion.identity);
            }
        }
    }
}
