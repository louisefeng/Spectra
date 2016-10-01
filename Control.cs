using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public float speed;

	private Rigidbody2D move;
	public GameObject bullet;
	public float yPosition;
	public GameObject ship;
	private double time;
	private double nextTime;
	//public Transform bulletSpawn;

	// Use this for initialization
	void Start () {
		
		time = 0.5;
		move = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 moving = new Vector2 (moveHorizontal, 0);
		move.velocity = moving * speed;

		if (Input.GetButton ("Fire1") && Time.time > nextTime) {
			nextTime = Time.time + time;
			Instantiate (bullet, new Vector3 (ship.transform.position.x, yPosition, 0), new Quaternion());
		}


	}
}
