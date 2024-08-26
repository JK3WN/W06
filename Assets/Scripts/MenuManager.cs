using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButton01Pressed()
    {
        SceneManager.LoadScene(1);
    }

    public void OnButton02Pressed()
    {
        SceneManager.LoadScene(2);
    }

    public void OnButton03Pressed()
    {

    }

    public void OnExitPressed()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
}
