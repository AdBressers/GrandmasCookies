using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlverwijderen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {

        print("wer?");
        if (col.gameObject.tag == "deletemap")
        {
            Destroy(gameObject);
        }
    }
}
