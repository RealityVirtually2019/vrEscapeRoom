using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PotionManager : MonoBehaviour
{
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
          
        }else if(col.gameObject.tag == "bottle")
        {
            
        };
    }
}
