using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public static Player Instance;
	public Transform groundPos;
	private highscore highScore;

	private Rigidbody2D rb;
	public float jumpForce = 500f;
	public float frameTime = 0.4f;
	public float moveSpeed = 250f;

	private SpriteRenderer spriteRend;
	public Sprite[] sprites = new Sprite[2];
	public Sprite[] deathSprites = new Sprite[6];
	private float animateTime;
	private int frame;
	private bool isDead;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		spriteRend = GetComponent<SpriteRenderer>();
		highScore = highscore.Instance;
	}

	private void Update()
	{
		float addSpeed = highScore.score;
		rb.velocity = new Vector2((moveSpeed + addSpeed) * Time.fixedDeltaTime, rb.velocity.y);

		if (animateTime > frameTime && !isDead)
		{
			animateTime = 0;
			frame = (frame + 1) % 2;
			spriteRend.sprite = sprites[frame];
		}
		animateTime += Time.deltaTime;
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("Springveer"))
		{
			rb.AddForce(transform.up * jumpForce);
		}
		if (col.gameObject.CompareTag("Obstacle"))
		{
			isDead = true;
			StartCoroutine(Death());
		}
	}

	private IEnumerator Death()
	{
		int index = 0;
		spriteRend.sprite = deathSprites[index];
		index++;
		yield return new WaitForSeconds(0.1f);
		spriteRend.sprite = deathSprites[index];
		index++;
		yield return new WaitForSeconds(0.1f);
		spriteRend.sprite = deathSprites[index];
		index++;
		yield return new WaitForSeconds(0.1f);
		spriteRend.sprite = deathSprites[index];
		index++;
		yield return new WaitForSeconds(0.1f);
		spriteRend.sprite = deathSprites[index];
		index++;
		yield return new WaitForSeconds(0.1f);
		spriteRend.sprite = deathSprites[index];

		SceneManager.LoadScene(2);
	}
}
