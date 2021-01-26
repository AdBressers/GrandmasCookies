using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscore : MonoBehaviour
{

    public Text stringscore;
    public Text Highscore;
    int score;
    public static bool givepoint;

    // Start is called before the first frame update
    void Start()
    {
        Highscore.text = PlayerPrefs.GetInt("HighScores", 0).ToString();
        score = 0;
        stringscore.text = score.ToString();
    }

    void extrascore()
    {
        score++;
        stringscore.text = score.ToString();

        if (score > PlayerPrefs.GetInt("HighScores", 0))
        {
            
            PlayerPrefs.SetInt("HighScores", score);
            Highscore.text = score.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            print("klik r");
            PlayerPrefs.DeleteKey("HighScores");
            Highscore.text = 0.ToString();
        }


        if (givepoint == true)
        {
            extrascore();
            givepoint = false;
        }
    }
}
