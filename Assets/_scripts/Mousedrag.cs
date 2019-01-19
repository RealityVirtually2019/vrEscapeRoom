using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousedrag : MonoBehaviour
{

    // Start is called before the first frame update
    private Vector3 screenPoint;
    private Vector3 offset;
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0) { Debug.Log("Horizontal"); }
        if (Input.GetAxis("Vertical") != 0) { Debug.Log("vert"); }
        if (Input.GetAxis("Axis 3") != 0) { Debug.Log("3rd"); }
        if (Input.GetAxis("Axis9") != 0) { Debug.Log("9"); }
        if (Input.GetAxis("Axis10") != 0) { Debug.Log("10"); }
        if (Input.GetAxis("Axis11") != 0) { Debug.Log("11"); }
        if (Input.GetAxis("Axis12") != 0) { Debug.Log("12"); }
        if (Input.GetKeyDown("joystick button 0")) { Debug.Log("button 0"); }
        if (Input.GetKeyDown("joystick button 1")) { Debug.Log("button 1"); }
        if (Input.GetKeyDown("joystick button 2")) { Debug.Log("button 2"); }

        if (Input.GetKeyDown("joystick button 10")) { Debug.Log("button 10"); }
        if (Input.GetKeyDown("joystick button 11")) { Debug.Log("button 11"); }
        if (Input.GetKeyDown("joystick button 12")) { Debug.Log("button 12"); }
        if (Input.GetKeyDown("joystick button 13")) { Debug.Log("button 13"); }
        if (Input.GetKeyDown("joystick button 14")) { Debug.Log("button 14"); }
        if (Input.GetKeyDown("joystick button 15")) { Debug.Log("button 15"); }
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
       // transform.position = Vector3.MoveTowards(transform.position, curPosition, 1.0f);
        GetComponent<Rigidbody>().velocity = ( curPosition - transform.position );

    }
    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Hand")
        {
            Debug.Log("Hand touching: " + transform.name);
            if (Input.GetAxis("Axis9") != 0)
            { GetComponent<Rigidbody>().velocity = (col.transform.position - transform.position); Debug.Log("9th"); }
            if (Input.GetAxis("Axis10") != 0)
            { GetComponent<Rigidbody>().velocity = (col.transform.position - transform.position); Debug.Log("10th"); }
           
        }
    }
}
