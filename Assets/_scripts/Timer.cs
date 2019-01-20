using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text secText;
    public Text minText;

    public GameObject Environment;

    public Transform PlayerPosition;
    public Transform EndScenePosition;

    public GameObject EndScene;
    public Text EndTxt;

    public float secVal;
    public float minVal;
    public bool isWin = false;

    public string sceneName;

    void Awake()
    {
        StartCoroutine(StartCountdown());
    }

    public IEnumerator StartCountdown()
    {
        secVal = 59;
        minVal = 9;
        minText.text = "0" + minVal;
        while(minVal > -1)
        {
            if(secVal >= 10)
            {
                secText.text = secVal.ToString();
            }else if (secVal >= 0 && secVal < 10){
                secText.text = "0" + secVal.ToString();
            }else if (secVal < 0 && minVal > 0)
            {
                minVal--;
                minText.text = "0" + minVal;
                secVal = 59;
            }
            yield return new WaitForSeconds(1.0f);
            secVal--;
        }
    }

    void Update()
    {
        if (isWin == true)
        {
            StartCoroutine(GameWin());
        }
        else if (minVal == 0 && secVal == 0 && isWin == false)
        {
            StartCoroutine(GameLost());
        }
    }

    public IEnumerator GameWin()
    {
        Environment.GetComponent<Animator>().Play("EnvMove");
        yield return new WaitForSeconds(2.0f);
        PlayerPosition.position = new Vector3(EndScenePosition.position.x, EndScenePosition.position.y, EndScenePosition.position.z);
        EndScene.SetActive(true);
        EndTxt.text = "You won!";
        yield return new WaitForSeconds(5.0f);
        ReplayGame(sceneName);
    }

    public IEnumerator GameLost()
    {
        yield return new WaitForSeconds(2.0f);
        Environment.GetComponent<Animator>().Play("EnvMove");
        yield return new WaitForSeconds(3.0f);
        PlayerPosition.position = new Vector3(EndScenePosition.position.x, EndScenePosition.position.y, EndScenePosition.position.z);
        yield return new WaitForSeconds(1.0f);
        EndScene.SetActive(true);
        EndTxt.text = "You lost...";
        yield return new WaitForSeconds(5.0f);
        ReplayGame(sceneName);
    }

    public void ReplayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
