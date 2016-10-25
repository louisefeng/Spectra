using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {
	//public int[] total;
	public int max;
    public int screenLimit;
	private int maxEnemies = 20;
	public movement enemy0;
    public enemyShoot bullet0;
	public movement enemy1;
    public enemyShoot bullet1;
    public movement enemy2;
    public enemyShoot bullet2;
    public movement enemy3;
    public enemyShoot bullet3;
    private static GameObject[] enemyList0 = new GameObject[20];
	private static GameObject[] enemyList1 = new GameObject[20];
	private static GameObject[] enemyList2 = new GameObject[20];
	private static GameObject[] enemyList3 = new GameObject[20];
    private static GameObject[] bulletList0 = new GameObject[200];
    private static GameObject[] bulletList1 = new GameObject[200];
    private static GameObject[] bulletList2 = new GameObject[200];
    private static GameObject[] bulletList3 = new GameObject[200];
    private List<movement> enemyTypes = new List<movement>(); 
    private List<enemyShoot> bulletTypes = new List<enemyShoot>();
    private GameObject[][] allEnemies = new GameObject[][] { enemyList0, enemyList1, enemyList2, enemyList3 };
    private GameObject[][] allBullets = new GameObject[][] { bulletList0, bulletList1, bulletList2, bulletList3 };

	public double delay0;
	public double delay1;
	public double delay2;
	public double delay3;
    /*public double shootTime0;
    public double shootTime1;
    public double shootTime2;
    public double shootTime3;
    private double shootingTime0;
    private double shootingTime1;
    private double shootingTime2;
    private double shootingTime3;*/
    public double spawnTime0;
	public double spawnTime1;
	public double spawnTime2;
	public double spawnTime3;
	private double nextTime0;
	private double nextTime1;
	private double nextTime2;
	private double nextTime3;

	private int num0;
	private int num1;
	private int num2;
	private int num3;
    private int spawns0;
    private int spawns1;
    private int spawns2;
    private int spawns3;
    private int shot0;
    private int shot1;
    private int shot2;
    private int shot3;
    private List<int> shotsTaken = new List<int>();

    // Use this for initialization
    void Start (){
        enemyTypes.Add(enemy0);
        enemyTypes.Add(enemy1);
        enemyTypes.Add(enemy2);
        enemyTypes.Add(enemy3);
        bulletTypes.Add(bullet0);
        bulletTypes.Add(bullet1);
        bulletTypes.Add(bullet2);
        bulletTypes.Add(bullet3);
        shotsTaken.Add(shot0);
        shotsTaken.Add(shot1);
        shotsTaken.Add(shot2);
        shotsTaken.Add(shot3);
        for (int x = 0; x < 4; x++)
        {
            GameObject bullet = bulletTypes[x].gameObject;
            GameObject enemy = enemyTypes[x].gameObject;
            for (int y = 0; y < allEnemies[x].Length; y++)
            {
                GameObject tempEnemy = Instantiate(enemy, new Vector3(10, 10, 0), new Quaternion()) as GameObject;
                tempEnemy.SetActive(false);
                allEnemies[x][y] = tempEnemy;
            }
            for (int z = 0; z < allBullets[x].Length; z++)
            {
                GameObject tempBullet = Instantiate(bullet, new Vector3(10, 10, 0), new Quaternion()) as GameObject;
                tempBullet.SetActive(false);
                allBullets[x][z] = tempBullet;
            }
        }
        /*
		for (int x = 0; x < maxEnemies; x++) {
			int y = 0;
			GameObject enemy = enemy0.gameObject;
			GameObject tempEnemy = Instantiate (enemy, new Vector3 (10, 10, 0), new Quaternion ()) as GameObject;
			tempEnemy.SetActive (false);
			enemyList0[x] = tempEnemy;
			y += 1;

			enemy = enemy1.gameObject;
			tempEnemy = Instantiate (enemy, new Vector3 (10, 10, 0), new Quaternion ()) as GameObject;
			tempEnemy.gameObject.SetActive (false);
			enemyList1[x] = tempEnemy;
			y += 1;

			enemy = enemy2.gameObject;
			tempEnemy = Instantiate (enemy, new Vector3 (10, 10, 0), new Quaternion ()) as GameObject;
			tempEnemy.gameObject.SetActive (false);
			enemyList2[x] = tempEnemy;
			y += 1;

			enemy = enemy3.gameObject;
			tempEnemy = Instantiate (enemy, new Vector3 (10, 10, 0), new Quaternion ()) as GameObject;
			tempEnemy.gameObject.SetActive (false);
			enemyList3[x] = tempEnemy;
		}
        */
	}

    public GameObject[] allBull(int x)
    {
        if (x >= 0 && x <= 3)
        {
            return allBullets[x];
        }
        return null;
    }


    public GameObject[] allEnem(int x)
    {
        if (x >= 0 && x <= 3)
        {
            return allEnemies[x];
        }
        return null;
    }

	public void num(int x) {
		switch(x) {
		case 0:
			num0 -= 1;
			break;
		case 1:
			num1 -= 1;
			break;
		case 2:
			num2 -= 1;
			break;
		case 3:
			num3 -= 1;
			break;
		}
	}

    public void decrementShot(int x)
    {
        shotsTaken[x] -= 1;
    }

    public void incrementShot(int x)
    {
        shotsTaken[x] += 1;
    }

    public int returnShot(int x)
    {
        return shotsTaken[x];
    }
	
	// Update is called once per frame
	void Update () {
		if (Time.time > delay0 && Time.time > nextTime0 && spawns0 < max && num0 < screenLimit) {
			nextTime0 = Time.time + spawnTime0;
			GameObject temp = enemyList0 [num0];
			temp.transform.position = new Vector3(enemy0.startPosX, enemy0.startPosY, 0);
            temp.GetComponent<movement>().setSpawnTime(temp.GetComponent<movement>().getRandomShootingTime());
            //temp.transform.localScale.Scale(new Vector3(2, 2, 1));
            temp.gameObject.SetActive (true);
			num0 += 1;
            spawns0 += 1;
		}
		if (Time.time > delay1 && Time.time > nextTime1 && spawns1 < max && num1 < screenLimit) {
			nextTime1 = Time.time + spawnTime1;
			GameObject temp = enemyList1 [num1];
			temp.transform.position = new Vector3 (enemy1.startPosX, enemy1.startPosY, 0);
            temp.GetComponent<movement>().setSpawnTime(temp.GetComponent<movement>().getRandomShootingTime());
            temp.gameObject.SetActive (true);
			num1 += 1;
            spawns1 += 1;
		}

		if (Time.time > delay2 && Time.time > nextTime2 && spawns2 < max && num2 < screenLimit) {
			nextTime2 = Time.time + spawnTime2;
			GameObject temp = enemyList2 [num2];
			temp.transform.position = new Vector3 (enemy2.startPosX, enemy2.startPosY, 0);
            temp.GetComponent<movement>().setSpawnTime(temp.GetComponent<movement>().getRandomShootingTime());
            temp.gameObject.SetActive (true);
			num2 += 1;
            spawns2 += 1;
		}

		if (Time.time > delay3 && Time.time > nextTime3 && spawns3 < max && num3 < screenLimit) {
			nextTime3 = Time.time + spawnTime3;
			GameObject temp = enemyList3 [num3];
			temp.transform.position = new Vector3 (enemy3.startPosX, enemy3.startPosY, 0);
            temp.GetComponent<movement>().setSpawnTime(temp.GetComponent<movement>().getRandomShootingTime());
            temp.gameObject.SetActive (true);
			num3 += 1;
            spawns3 += 1;
		}
	}
}