using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl : MonoBehaviour
{
    bool isPlacingObject;
    GameObject objectPlacing;
    GameObject platformObject;
    GameObject jumpObject;
    GameObject crateObject;
    [SerializeField]
    float Distance = 10.0f;

    [Header("Prefabs")]
    public GameObject platform;
    public GameObject jumpPad;
    public GameObject Crate;

    void Update()
    {
        if(isPlacingObject)
		{
            if(objectPlacing != null)
			{
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = Distance;
                objectPlacing.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
                if (Input.GetMouseButtonDown(0))
                {
                    isPlacingObject = false;
                    objectPlacing.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    objectPlacing = null;
                }
            }
        }

		if (Input.GetKeyDown(KeyCode.Space) && !isPlacingObject)
		{
            if(platformObject != null)
			{
                Destroy(platformObject);
			}
            
            if (jumpObject != null)
			{
                Destroy(jumpObject);
			}

            if (crateObject != null)
			{
                Destroy(crateObject);
			}
		}
    }

    public void OnPlatformSelect()
    {
        if (!isPlacingObject && platformObject == null)
        {
            isPlacingObject = true;
            platformObject = Instantiate(platform, Vector3.zero, Quaternion.identity);
            objectPlacing = platformObject;
        }
    }

    public void OnJumpSelect()
	{
        if(!isPlacingObject && jumpObject == null)
		{
            isPlacingObject = true;
            jumpObject = Instantiate(jumpPad, Vector3.zero, Quaternion.identity);
            objectPlacing = jumpObject;
        }
	}

    public void OnCrateSelect()
    {
        if (!isPlacingObject && crateObject == null)
        {
            isPlacingObject = true;
            crateObject = Instantiate(Crate, Vector3.zero, Quaternion.identity);
            objectPlacing = crateObject;
        }
    }
}