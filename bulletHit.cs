using UnityEngine;
using System.Collections;

public class bulletHit : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D col) {
		//print (col.gameObject.name);
		//print (collisionItem.name);
		if (col.gameObject.name == "Bullet(Clone)") {
			Destroy (col.gameObject);
		}
	}

}
