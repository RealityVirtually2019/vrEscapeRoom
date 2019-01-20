using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leveer : MonoBehaviour
{
    public Cauldron cauldron;
    public GameObject indicator,spawnShelf;
    public int type;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (type)
            {
                case 1:
                    cauldron.Flush();
                    GameObject clone = Instantiate(indicator, transform.position + (transform.right.normalized * -2), transform.rotation) as GameObject;
                    break;
                case 2:
                    Application.LoadLevel(Application.loadedLevel);
                    break;
                case 3:
                    spawnShelf.GetComponent<Spawner>().SpawnObjects();
                    break;
                default:
                    break;
            }
        }
    }
}
