using UnityEngine;
using System.Collections;

public class bulletHit : MonoBehaviour {

	public GameObject collisionItem;

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.name == "Bullet") {
			Destroy (col.gameObject);
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
