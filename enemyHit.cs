using UnityEngine;
using System.Collections;

public class enemyHit : MonoBehaviour {

	private SpriteRenderer enemySpriteRenderer;
	private SpriteRenderer spriteRenderer;
	public GameObject self;

	void OnCollisionEnter2D (Collision2D col) {
		//print (col.gameObject.name);
		//print (collisionItem.name);
		spriteRenderer = GetComponent<SpriteRenderer> ();
		enemySpriteRenderer = col.gameObject.GetComponent<SpriteRenderer>();
		/*
		 * if (col.gameObject.name == "Enemy(Clone)" 
			&& spriteRenderer.sortingLayerName == enemySpriteRenderer.sortingLayerName
		) {
			Destroy (col.gameObject);
		}
		*/

		switch(spriteRenderer.sortingLayerName){
		case "0":
			//print (col.gameObject.name);
			if (col.gameObject.name == "Enemy0(Clone)") {
				Destroy (col.gameObject);
			} else {
				Physics2D.IgnoreCollision (col.collider, self.GetComponent<Collider2D> ());
			}
			break;
		case "1":
			//print (col.gameObject.name);
			if (col.gameObject.name == "Enemy1(Clone)") {
				Destroy (col.gameObject);
			} else {
				Physics2D.IgnoreCollision (col.collider, self.GetComponent<Collider2D> ());
			}
			break;
		case "2":
			//print (col.gameObject.name);
			if (col.gameObject.name == "Enemy2(Clone)") {
				Destroy (col.gameObject);
			} else {
				Physics2D.IgnoreCollision (col.collider, self.GetComponent<Collider2D> ());
			}
			break;
		case "3":
			//print (col.gameObject.name);
			if (col.gameObject.name == "Enemy3(Clone)") {
				Destroy (col.gameObject);
			} else {
				Physics2D.IgnoreCollision (col.collider, self.GetComponent<Collider2D> ());
			}
			break;
		}


	}
}
