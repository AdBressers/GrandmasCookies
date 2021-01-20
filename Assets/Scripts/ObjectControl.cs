using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl : MonoBehaviour
{
    bool isPlacingObject;
    GameObject objectPlacing;
    GameObject blockObject;
    GameObject jumpObject;
    [SerializeField]
    float Distance = 10.0f;

    [Header("Prefabs")]
    public GameObject Block;
    public GameObject jumpPad;

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
                    objectPlacing.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    objectPlacing = null;
                }
            }
        }

		if (Input.GetKeyDown(KeyCode.Space) && !isPlacingObject)
		{
            if(blockObject != null)
			{
                Destroy(blockObject);
                blockObject = null;
			}
            
            if (jumpObject != null)
			{
                Destroy(jumpObject);
                jumpObject = null;
			}
		}
    }

    public void OnBlockSelect()
    {
        if (!isPlacingObject && blockObject == null)
        {
            isPlacingObject = true;
            blockObject = Instantiate(Block, Vector3.zero, Quaternion.identity);
            objectPlacing = blockObject;
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
}