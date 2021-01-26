using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPlatforms : MonoBehaviour
{
    private Player player;
	private Collider2D coll;
	public Transform platformPos;

	private void Start()
	{
		player = Player.Instance;
		coll = GetComponent<Collider2D>();
	}

	private void Update()
	{
		coll.isTrigger = player.groundPos.position.y <= platformPos.position.y;
	}
}
