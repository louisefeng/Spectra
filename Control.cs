using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public float speed;

	private Rigidbody2D move;

	// Use this for initialization
	void Start () {
	
		move = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 moving = new Vector2 (moveHorizontal, 0);
		move.velocity = moving * speed;
		//move.AddForce (moving * speed);


	}
}
