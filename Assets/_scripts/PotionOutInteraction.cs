using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionOutInteraction : MonoBehaviour
{
    public int currentPotion = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("On your head!");
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "chest")
        {
            if(currentPotion == 1)
            {
                col.gameObject.GetComponent<ChestInteraction>().RedLockOn();
                Destroy(gameObject);
            };
            if (currentPotion == 2)
            {
                col.gameObject.GetComponent<ChestInteraction>().BlueLockOn();
                Destroy(gameObject);
            };
            if (currentPotion == 3)
            {
                col.gameObject.GetComponent<ChestInteraction>().GreenLockOn();
                Destroy(gameObject);
            };
        }
    }

}
