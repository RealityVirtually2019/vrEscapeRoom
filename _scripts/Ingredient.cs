using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public int color;
    public int temperature;
    public int texture;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
