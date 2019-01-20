using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public Vector3 mix; //color,temp,texture
    public GameObject spawnEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter(Collider collision)
    {
        

     }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain" && spawnEffect != null)
        {
            GetComponent<Collider>().enabled = false;
            Instantiate(spawnEffect, transform.position,transform.rotation);
            Destroy(this.gameObject);
        }
        if (collision.transform.name == "iceblock(Clone)" && mix == Vector3.one)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
