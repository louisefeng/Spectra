using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public float speed;
	private Rigidbody2D move;
	public static GameObject collisionItem;
	public double time;
	private double nextTime;
	public Sprite sp1;
	public Sprite sp2;
	public Sprite sp3;
	public Sprite sp4;
	public int shipNum;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		move = GetComponent<Rigidbody2D> ();
	}

	public class BulletHit : MonoBehaviour {
		void OnCollisionEnter (Collision col) {
			if (col.gameObject.name == "Background") {
				Destroy(col.gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 moving = new Vector2 (0, speed);
		move.velocity = moving * speed;
	
		if (Input.GetButton("colorChange") && Time.time > nextTime) {
			nextTime = Time.time + time;
			shipNum = (shipNum + 1) % 4;
			switch (shipNum) {
			case 0:
				spriteRenderer.sprite = sp1;
				break;
			case 1:
				spriteRenderer.sprite = sp2;
				break;
			case 2:
				spriteRenderer.sprite = sp3;
				break;
			case 3:
				spriteRenderer.sprite = sp4;
				break;
			}
		}
	}
}
