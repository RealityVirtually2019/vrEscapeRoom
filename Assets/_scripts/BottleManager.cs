using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    public Material emptyBottleMaterial;
    public GameObject bottlePotion;
    public Transform bottleTop;
    public Transform bottleBot;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(bottleTop.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (bottleTop.position.y < bottleBot.position.y)
        {
            bottlePotion.GetComponent<Renderer>().material = emptyBottleMaterial;
        }
    }
}
