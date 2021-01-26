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

	private void OnCollisionStay2D(Collision2D col)
	{
		if(gameObject.tag == "Crate" && col.collider.CompareTag("Obstacle") && !isUsed)
		{
			Destroy(col.gameObject);
			GetComponent<Collider2D>().isTrigger = true;
			rb.isKinematic = true;
			rb.velocity = Vector2.zero;
			isUsed = true;
		}

		if (col.collider.CompareTag("Player"))
		{
			if(CompareTag("Springveer"))
			{
				anim.SetTrigger("Activate");
				GetComponent<Collider2D>().isTrigger = true;
				rb.isKinematic = true;
				rb.velocity = Vector2.zero;
				isUsed = true;
			}
			if (CompareTag("Platform"))
			{
				GetComponent<Collider2D>().isTrigger = true;
				rb.isKinematic = true;
				rb.velocity = Vector2.zero;
				isUsed = true;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("deletemap"))
		{
			Destroy(gameObject);
		}
	}
}
