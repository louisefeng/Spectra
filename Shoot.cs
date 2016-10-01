using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public float speed;
	private Rigidbody2D move;
	public static GameObject collisionItem;

	// Use this for initialization
	void Start () {
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
	
	}
}
