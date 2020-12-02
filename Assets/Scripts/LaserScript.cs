using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + 4.4f * Time.deltaTime, transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x , transform.position.y + 2.0f * Time.deltaTime, transform.position.z);
    
        if (transform.position.y >= 1.5f )
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);    

    }
}
