using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Control : MonoBehaviour
{
	float Distance = 10.0f;
	Rigidbody2D rb;
	bool isUsed;

	Animator anim;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
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

	private void OnCollisionEnter2D(Collision2D col)
	{
		if(gameObject.tag == "Crate" && col.collider.CompareTag("Obstacle") && !isUsed)
		{
			Destroy(col.gameObject);
			GetComponent<Collider>().isTrigger = true;
			rb.isKinematic = true;
			isUsed = true;
		}

		if (col.collider.CompareTag("Player"))
		{
			isUsed = true;
			if(CompareTag("Springveer"))
			{
				anim.SetTrigger("Activate");
			}
		}
	}
}