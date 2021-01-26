using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBorder : MonoBehaviour
{

	private void LateUpdate()
	{
		transform.position = new Vector3(transform.position.x, -9.15f, 0.0f);
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag("Player"))
		{
			SceneManager.LoadScene(2);
		}
	}
}
