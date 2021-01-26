using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public float moveSpeed = 0.4f;

	private void Update()
	{
		transform.Rotate(0, 0, moveSpeed * (Time.deltaTime * 50.0f));
		transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0), Space.World);
	}
}
