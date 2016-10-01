using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public float speed;

	private Rigidbody2D move;
	public GameObject bullet;
	public float yPosition;
	public GameObject ship;
	public double time;
	private double bulletNextTime;
	private double shipNextTime;
	public Sprite sp1;
	public Sprite sp2;
	public Sprite sp3;
	public Sprite sp4;
	private int shipNum;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		
		shipNum = 0;
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = sp1;
		move = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 moving = new Vector2 (moveHorizontal, 0);
		move.velocity = moving * speed;

		if (Input.GetButton ("Fire1") && Time.time > bulletNextTime) {
			bulletNextTime = Time.time + time;
			Instantiate (bullet, new Vector3 (ship.transform.position.x, yPosition, 0), new Quaternion());
		}

		if (Input.GetButton("colorChange") && Time.time > shipNextTime) {
			shipNextTime = Time.time + time;
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