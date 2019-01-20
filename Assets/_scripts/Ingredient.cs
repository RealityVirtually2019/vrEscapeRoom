using System.Collections;
using System.Collections.Generic;
using HTC.UnityPlugin.Vive;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BasicGrabbable))]
public class Ingredient : MonoBehaviour
{

    public Vector3 mix;

    // Start is called before the first frame update
    void Start()
    {
       // "temp<> texture<> color"
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wand")
        { GameObject clone = Instantiate(this.gameObject, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z + 2), transform.rotation) as GameObject;
            clone.transform.localScale = transform.localScale;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Spawn" )
        {

            GameObject clone = Instantiate(this.gameObject, other.transform.position, other.transform.rotation) as GameObject;
            clone.transform.localScale = transform.localScale;
        }
    }
}
