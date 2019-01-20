using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    public Material emptyBottleMaterial;
    public GameObject bottlePotion;
    public GameObject potionOut,insideSPot, brokenGlass;
    public Transform bottleTop;
    public Transform bottleBot;
    public bool bottleFilled;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bottleTop.position.y < bottleBot.position.y )
        {
            if (potionOut != null)
            {
                potionOut.GetComponent<DieTime>().lifetime = 4.0f;
                potionOut.transform.position = bottleTop.transform.position;
                //potionOut.transform.rotation = transform.rotation;
                potionOut.GetComponent<Collider>().enabled = true;
                potionOut.GetComponent<Rigidbody>().isKinematic = false;
                potionOut.transform.parent = null;
                potionOut = null;
            }

           
            //potionDrop.GetComponent<Renderer>().material = bottlePotion.GetComponent<Renderer>().material;
            //bottlePotion.GetComponent<Renderer>().material = emptyBottleMaterial;
            //bottleFilled = false;
        }
    }
    public void FillBottle(GameObject newPotion)
    {
        if (potionOut != null)
        {
            potionOut.GetComponent<DieTime>().lifetime = 4.0f;
            potionOut.transform.position = transform.up.normalized * 1;
           // potionOut.transform.rotation = transform.rotation;
            potionOut.GetComponent<Collider>().enabled = true;
            potionOut.GetComponent<Rigidbody>().isKinematic = false;
            potionOut.transform.parent = null;
            potionOut = null;
        }
        potionOut = Instantiate(newPotion, insideSPot.transform.position,transform.rotation) as GameObject;
        potionOut.transform.parent = this.transform;
        
        potionOut.transform.rotation = transform.rotation;

    }
    public void OnCollisionEnter(Collision collision)
    {
      
        if (collision.impulse.magnitude > 3)
        { 
            if (potionOut != null)
            {

                // potionOut.transform.position = transform.up.normalized * 1;
                // potionOut.transform.rotation = transform.rotation;

                potionOut.GetComponent<DieTime>().lifetime = 4.0f;
                potionOut.GetComponent<Collider>().enabled = true;
                potionOut.GetComponent<Rigidbody>().isKinematic = false;
                potionOut.transform.parent = null;
                Instantiate(potionOut, transform.position + transform.right.normalized * 0.1f, transform.rotation);
                Instantiate(potionOut, transform.position + transform.right.normalized * -0.1f, transform.rotation);
                Instantiate(potionOut, transform.position + transform.up.normalized * 0.1f, transform.rotation);
                Instantiate(potionOut, transform.position + transform.up.normalized * -0.1f, transform.rotation);
                potionOut = null;
            }

            Instantiate(brokenGlass,transform.position,transform.rotation);
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Spawn")
        {

            GameObject clone = Instantiate(this.gameObject, other.transform.position, other.transform.rotation) as GameObject;
            clone.transform.localScale = transform.localScale;
        }
    }
}
