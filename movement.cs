using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	
	public float speed;

	private Rigidbody2D move;

	private double nextTime;
	public double spawnTime;

	public GameObject self;
	public GameObject walls;

	private Collider2D wall;

	public float startPosX;
	public float startPosY;
	private double yPos = 0;
	private double xPos;
	public double yMaxRange;

	public Vector2 direction;

	private float yVal = 1;
	public float xVal = 1;

	// Use this for initialization
	void Start () {
		
		move = GetComponent<Rigidbody2D> ();
		wall = walls.GetComponent<Collider2D> ();

		/* This part makes it bounce around erratically
		Vector2 moving = direction;
		move.velocity = moving * speed;
		*/
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "Background") {
			xVal = xVal * -1;
		}
	}


	//Box size limit: 1.45, bottom is -1

	// Update is called once per frame
	void Update () {
		/*if (Time.time > nextTime && self.name == "Enemy0") {
			nextTime = Time.time + spawnTime;
			Instantiate (self, new Vector3(startPosX, startPosY, 0), new Quaternion (), self.transform);
		}
		*/
		if (Time.time > nextTime && self.name == "Enemy0") {
			nextTime = Time.time + spawnTime;
			Vector2 moving = new Vector2 (direction.x * xVal, direction.y * yVal);
			move.velocity = moving * speed;
			//move.AddForce(moving * speed);
			yPos += Mathf.Abs (direction.y);
			print ("x = " + move.position.x + " y = " + move.position.y + " yPos = " + yPos);

			if (yPos > yMaxRange - 1) {
				yPos = 0;
				yVal = yVal * -1;
			}
		}
		//move.transform.position.x += moving.x;
		//move.transform.position.y += moving.y;
	}
}
