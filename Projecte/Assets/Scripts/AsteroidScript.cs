using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    Vector3 pos;
    public float velocitat;

    // Start is called before the first frame update
    void Start()
    {
        float y = Random.Range(-15.0f, -9.0f);
        float z = transform.position.z;
        pos = new Vector3(5.0f + z, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, velocitat * Time.deltaTime);
        if (transform.position == pos)
        {
            Destroy(transform.gameObject);
        }
    }
}
