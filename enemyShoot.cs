using UnityEngine;
using System.Collections;

public class enemyShoot : MonoBehaviour
{
    public float speed;
    public GameObject self;
    private Rigidbody2D move;

    private GameObject player;
    private Spawn spawner;

    // Use this for initialization
    void Start()
    {
        
    }

    void Awake()
    {
        spawner = GameObject.Find("EnemyGenerator").GetComponent<Spawn>();
        player = GameObject.Find("Player");
        move = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && player.GetComponent<SpriteRenderer>().sortingLayerName.Equals(GetComponent<SpriteRenderer>().sortingLayerName))
        {
            player.GetComponent<Control>().beenHit();
            self.SetActive(false);
            int importantNum = bulletNum(GetComponent<SpriteRenderer>().sortingLayerName);
            spawner.decrementShot(importantNum);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moving = new Vector2(0, speed);
        move.velocity = moving * speed * -1;

        if (self.transform.position.y < -4)
        {
            self.SetActive(false);
            int importantNum = bulletNum(GetComponent<SpriteRenderer>().sortingLayerName);
            spawner.decrementShot(importantNum);
        }
    }

    int bulletNum(string bul)
    {
        switch (bul)
        {
            case "0":
                return 0;
            case "1":
                return 1;
            case "2":
                return 2;
            case "3":
                return 3;
        }
        return 0;
    }
}
