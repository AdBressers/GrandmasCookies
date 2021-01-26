using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class snenemanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuscene();
        }
    }

    public static void startscene()
    {
        SceneManager.LoadScene(0);
    }
    public static void menuscene()
    {
        SceneManager.LoadScene(1);
    }

    public static void quit()
    {
        Application.Quit();
    }
    public static void gestart()
    {
        SceneManager.LoadScene(2);
    }
}
