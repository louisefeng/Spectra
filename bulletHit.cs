using UnityEngine;
using System.Collections;

public class bulletHit : MonoBehaviour {

	private SpriteRenderer bulletSpriteRenderer;
	private SpriteRenderer spriteRenderer;

	void OnTriggerEnter2D (Collider2D col) {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		bulletSpriteRenderer = col.gameObject.GetComponent<SpriteRenderer>();
		if (col.gameObject.name == "Bullet(Clone)" 
			&& spriteRenderer.sortingLayerName == bulletSpriteRenderer.sortingLayerName
		) {
			spriteRenderer.gameObject.SetActive(false);
		}
	}

}
