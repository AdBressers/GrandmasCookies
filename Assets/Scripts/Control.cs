using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
	float Distance = 10.0f;
	Rigidbody rb;
	bool isUsed;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void OnMouseDrag()
	{
		if(!isUsed)
		{
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = Distance;
			transform.position = Camera.main.ScreenToWorldPoint(mousePos);
			rb.velocity = Vector3.zero;
		}
	}

	private void OnTriggerEnter(Collider col)
	{
		if(col.tag == gameObject.tag && !isUsed)
		{
			transform.localScale = Vector3.one * 2;
			isUsed = true;
		}
	}
}
