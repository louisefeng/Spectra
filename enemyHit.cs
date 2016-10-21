using UnityEngine;
using System.Collections;

public class enemyHit : MonoBehaviour {
    
	private SpriteRenderer spriteRenderer;
	public GameObject self;

	void OnCollisionEnter2D (Collision2D col) {
		spriteRenderer = GetComponent<SpriteRenderer> ();

		switch(spriteRenderer.sortingLayerName){
		case "0":
			if (col.gameObject.name == "Enemy0") {
				Destroy (col.gameObject);
			} else {
				Physics2D.IgnoreCollision (col.collider, self.GetComponent<Collider2D> ());
			}
			break;
		case "1":
			if (col.gameObject.name == "Enemy1") {
				Destroy (col.gameObject);
			} else {
				Physics2D.IgnoreCollision (col.collider, self.GetComponent<Collider2D> ());
			}
			break;
		case "2":
			if (col.gameObject.name == "Enemy2") {
				Destroy (col.gameObject);
			} else {
				Physics2D.IgnoreCollision (col.collider, self.GetComponent<Collider2D> ());
			}
			break;
		case "3":
			if (col.gameObject.name == "Enemy3") {
				Destroy (col.gameObject);
			} else {
				Physics2D.IgnoreCollision (col.collider, self.GetComponent<Collider2D> ());
			}
			break;
		}


	}
}
