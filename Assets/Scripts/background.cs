using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{

    private float lengte, startpos;
    public GameObject cam;
    public float parallaxeffect;




    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        lengte = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxeffect));
        float dist = (cam.transform.position.x * parallaxeffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        if (temp > startpos + lengte) startpos += lengte;
        else if (temp < startpos - lengte) startpos -= lengte;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
