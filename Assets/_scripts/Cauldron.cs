using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{

    public Vector3 mix; //color,temp,texture
    public Material[] colors;
    public Mesh[] shapes;
    public List<Vector3> potionList;
    public List<GameObject> potions;
    public List<GameObject> effects;
    public GameObject liquid,hot,cold;
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
        {
            case 1:
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
    public GameObject PotionList()
    {
        


        if (potionList.Contains(mix)) {
            Debug.Log("what mix to get potion of: " + mix);
            return potions[potionList.IndexOf(mix)];
        }
        else {
            return potions[potions.Count - 1];
            //dud potion
        }

      
    }
    public void Mix(Vector3 added)
    {
        //        -Shrinking / growing potion yellow +hot + smooth / yellow + cold + rough
        //  - dissappear / invisible  red + cold + smooth
        //     - ice   blue + cold + smooth
        //      - fire  red + hot + rough
        //       - Reappear black + cold + smooth
        //        - peptobismal red + mild + smooth
        //if (added.x == 1)
        //{
        //    GameObject clone = Instantiate(effects[0], transform.position, transform.rotation) as GameObject;
        //    clone.GetComponent<DieTime>().lifetime = 0.5f; if (clone.GetComponent<Rigidbody>() != null) { clone.GetComponent<Rigidbody>().AddForce(Vector3.up * 5.0f * Time.deltaTime); }
        //}
        //else if (added.x == -1)
        //{
        //    GameObject clone = Instantiate(effects[1], transform.position, transform.rotation) as GameObject;
        //    clone.GetComponent<DieTime>().lifetime = 0.5f; if (clone.GetComponent<Rigidbody>() != null) { clone.GetComponent<Rigidbody>().AddForce(Vector3.up * 5.0f * Time.deltaTime); }
        //}
        //else if (added.x == 0)
        //{
        //    GameObject clone = Instantiate(effects[2], transform.position, transform.rotation) as GameObject;
        //    clone.GetComponent<DieTime>().lifetime = 0.5f; if (clone.GetComponent<Rigidbody>() != null) { clone.GetComponent<Rigidbody>().AddForce(Vector3.up * 5.0f * Time.deltaTime); }
        //}
        //else if (added.x == 0)

        //{
        //    GameObject clone = Instantiate(effects[2], transform.position, transform.rotation) as GameObject;
        //    clone.GetComponent<DieTime>().lifetime = 0.5f; if (clone.GetComponent<Rigidbody>() != null) { clone.GetComponent<Rigidbody>().AddForce(Vector3.up * 5.0f * Time.deltaTime); }
        //}
        //else if (added.y == -1)

        //{
        //    GameObject clone = Instantiate(effects[4], transform.position, transform.rotation) as GameObject;
        //    clone.GetComponent<DieTime>().lifetime = 0.5f; if (clone.GetComponent<Rigidbody>() != null) { clone.GetComponent<Rigidbody>().AddForce(Vector3.up * 5.0f * Time.deltaTime); }
        //}
        //else if (added.y == 1)

        //{
        //    GameObject clone = Instantiate(effects[3], transform.position, transform.rotation) as GameObject;
        //    clone.GetComponent<DieTime>().lifetime = 0.5f; if (clone.GetComponent<Rigidbody>() != null) { clone.GetComponent<Rigidbody>().AddForce(Vector3.up * 5.0f * Time.deltaTime); }
        //}
        //else if (added.z == -1)

        //{
        //    GameObject clone = Instantiate(effects[6], transform.position, transform.rotation) as GameObject;
        //    clone.GetComponent<DieTime>().lifetime = 0.5f; if (clone.GetComponent<Rigidbody>() != null) { clone.GetComponent<Rigidbody>().AddForce(Vector3.up * 5.0f * Time.deltaTime); }
        //}
        //else
        //{
        //    GameObject clone = Instantiate(effects[3], transform.position, transform.rotation) as GameObject;
        //    clone.GetComponent<DieTime>().lifetime = 0.5f; if (clone.GetComponent<Rigidbody>() != null) { clone.GetComponent<Rigidbody>().AddForce(Vector3.up * 5.0f * Time.deltaTime); }
        //}
       
        //temp<> texture<> color
        mix = new Vector3(mix.x + added.x, mix.y + added.y, mix.z + added.z);
        if (mix.x > 1)
        { mix = new Vector3(1,mix.y,mix.z); }
        if (mix.x < -1)
        { mix = new Vector3(-1, mix.y, mix.z); }
        if (mix.y > 1)
        { mix = new Vector3(mix.x,1, mix.z); }
        if (mix.y < -1)
        { mix = new Vector3(mix.x, -1, mix.z); }
        if (mix.z > 1)
        { mix = new Vector3(mix.x, mix.y, 1); }
        if (mix.z < -1)
        { mix = new Vector3(mix.x, mix.y, -1); }


    }
    public void Flush()
    {
        mix = Vector3.zero;
        liquid.transform.GetComponent<Renderer>().material = colors[0];
        liquid.transform.GetComponent<MeshFilter>().mesh = shapes[0];
        hot.active = false;
        cold.active = false;
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<BottleManager>() != null)
        {
            collision.gameObject.GetComponent<BottleManager>().FillBottle(PotionList());
            //Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<Ingredient>() != null)
        {
            // MixColor(collision.gameObject.GetComponent<Ingredient>().color);
            Mix(collision.gameObject.GetComponent<Ingredient>().mix);
            
            
            hot.active = false;
            cold.active = false;
            if (mix.x > 0) { hot.active = true; }
            if (mix.x < 0) { cold.active = true; }

            //if (mix.y > 0) { liquid.transform.GetComponent<MeshFilter>().mesh = shapes[1]; }
            //else if (mix.y < 0) { liquid.transform.GetComponent<MeshFilter>().mesh = shapes[0]; }
            //else { liquid.transform.GetComponent<MeshFilter>().mesh = shapes[2]; }
          
            //if (mix.z > 0) { liquid.transform.GetComponent<Renderer>().material = colors[0]; }
            //else if (mix.z < 0) { liquid.transform.GetComponent<Renderer>().material = colors[1]; }
            //else { liquid.transform.GetComponent<Renderer>().material = colors[2]; }

           // GameObject clone = Instantiate(collision.gameObject, transform.position + (transform.right.normalized * 2) + (transform.up.normalized * 2), transform.rotation) as GameObject;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Wand")
        {
            if (enviroment.localScale.x == 2) { enviroment.localScale = new Vector3(1.0f, 1.0f, 1.0f); }
            else { enviroment.localScale = new Vector3(2.0f, 2.0f, 2.0f); }
            Destroy(collision.gameObject);
        }
        else { }
      
    }
}
