using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = lvlManager.border;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lvlManager.spawn = true;
        }
    }
}
