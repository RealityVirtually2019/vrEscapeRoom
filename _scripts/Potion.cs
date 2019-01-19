using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public Vector3 mix; //color,temp,texture
    public GameObject liquid,newPotion;
    public int currentColor;
    public Material[] colors;
    public Mesh[] shapes;
    public Transform enviroment;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MixTemp(int value)
    {
        switch (value)
        { case 1:
                break;
            default:
                break;
        }
    }
    public void MixTexture(int value)
    {
        
        switch (value)
        {
            case 1:
                break;
            default:
                break;
        }
    }
    public void MixColor(int value)
    {
        //positive or negative // zero is neutral
         currentColor += value; 
        if (currentColor > 5)
        { currentColor = 0; }
       // liquid.transform.GetComponent<Renderer>().material = colors[currentColor];
       // liquid.transform.GetComponent<MeshFilter>().mesh = shapes[currentColor];
        switch (value)
        {
            case 1:
                break;
            default:
                break;
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Ingredient>() != null)
        {
            MixColor(collision.gameObject.GetComponent<Ingredient>().color);
            GameObject newPot = Instantiate(newPotion, transform.position + (transform.up.normalized * 3) , transform.rotation) as GameObject;
            newPot.transform.GetChild(0).GetComponent<Renderer>().material = colors[currentColor];
            GameObject clone = Instantiate(collision.gameObject, transform.position + (transform.right.normalized * 5) + (transform.up.normalized * 2),transform.rotation) as GameObject;
            clone.transform.localScale = collision.transform.localScale;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Wand")
        { enviroment.localScale = new Vector3(3.0f,3.0f,3.0f); }

     }
}
