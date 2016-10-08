using UnityEngine;
using System.Collections;

public class bulletHitWall : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.name == "Bullet(Clone)") {
			Destroy (col.gameObject);
		}
	}

}