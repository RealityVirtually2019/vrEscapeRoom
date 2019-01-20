using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{

    public GameObject RedLock;
    public GameObject BlueLock;
    public GameObject GreenLock;
    public GameObject RedIcon;
    public GameObject BlueIcon;
    public GameObject GreenIcon;

    Color startColor;
    Color redLockColor;
    Color blueLockColor;
    Color greenLockColor;

    public bool hasRed;
    public bool hasBlue;
    public bool hasGreen;
    // Start is called before the first frame update
    void Start()
    {
        startColor = new Color(0.68868f, 0.66142f, 0.061721f, 1.0f);
        redLockColor = new Color(240f/255, 20f/255, 21f/255, 1.0f);
        blueLockColor = new Color(15f/255, 241f/255, 243f/255, 1.0f);
        greenLockColor = new Color(91f/255, 240f/255, 0.061721f, 1.0f);

        hasRed = false;
        hasBlue = false;
        hasGreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(hasRed && hasGreen && hasBlue)
        //{
        //    GetComponent<Animator>().SetTrigger("hasAll");
        //}
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.GetComponent<Potion>() != null)
        {
            if(col.gameObject.GetComponent<Potion>().mix.x == 1 && col.gameObject.GetComponent<Potion>().mix.y == 1 && col.gameObject.GetComponent<Potion>().mix.z == 1)
            {
                RedLockOn();
            }
            if (col.gameObject.GetComponent<Potion>().mix.x == -1 && col.gameObject.GetComponent<Potion>().mix.y == -1 && col.gameObject.GetComponent<Potion>().mix.z == -1)
            {
                BlueLockOn();
            }
            if (col.gameObject.GetComponent<Potion>().mix.x == 0 && col.gameObject.GetComponent<Potion>().mix.y == 1 && col.gameObject.GetComponent<Potion>().mix.z == 0)
            {
                GreenLockOn();
            }
        }
    }

    public void RedLockOn()
    {
        RedLock.GetComponent<Renderer>().materials[0].color = Color.Lerp(startColor, redLockColor, 100.0f);
        hasRed = true;
        RedIcon.SetActive(false);
        GetComponent<Animator>().SetTrigger("hasRed");
    }
    public void BlueLockOn()
    {
        BlueLock.GetComponent<Renderer>().materials[0].color = Color.Lerp(startColor, blueLockColor, 100.0f);
        hasBlue = true;
        BlueIcon.SetActive(false);
        GetComponent<Animator>().SetTrigger("hasBlue");
    }
    public void GreenLockOn()
    {
        GreenLock.GetComponent<Renderer>().materials[0].color = Color.Lerp(startColor, greenLockColor, 100.0f);
        hasGreen = true;
        GreenIcon.SetActive(false);
        GetComponent<Animator>().SetTrigger("hasGreen");
    }
}
