using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PotionManager : MonoBehaviour
{
    private bool isTopCollide = false;
    private bool isBotCollide = false;
    public int currentColor = 0;
    public Material[] potionMaterial;
    private GameObject bottlePotion;
    // Start is called before the first frame update
    void Start()
    {
        bottlePotion = GameObject.Find("BottlePotion");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ingredient")
        {
            currentColor = col.gameObject.GetComponent<Ingredient>().color;
            GetComponent<Renderer>().material = potionMaterial[currentColor];
        }else if(col.gameObject.tag == "bottle")
        {
            bottlePotion.GetComponent<Renderer>().material = potionMaterial[currentColor];
        };
    }
}
