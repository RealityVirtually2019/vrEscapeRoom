using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public Vector3 mix;
    public int type;
    public GameObject itemDrop;
    public List<GameObject> lockedObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Solved()
    {
        switch (type)
        {
            case 1:
                Destroy(this.gameObject);
                break;
            case 2:
                GetComponent<Collider>().enabled = false;
                Instantiate(itemDrop, transform.position + transform.up.normalized * 0.2f, transform.rotation);
                Destroy(this.gameObject);
                break;
            case 3:
                GetComponent<Collider>().enabled = false;
                foreach (GameObject go in lockedObjects)
                { go.GetComponent<Rigidbody>().isKinematic = false; }
                Destroy(this.gameObject);
                break;
            default:
                break;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Potion>() != null)
        {
            if (collision.gameObject.GetComponent<Potion>().mix == mix)
            {
                Solved();
            }
        }

    }
}
