using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	Rigidbody rb;
	public float jumpForce = 500f;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag("Springveer"))
		{
			col.collider.isTrigger = true;
			col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			rb.AddForce(Vector3.up * jumpForce);
		}
	}
}
