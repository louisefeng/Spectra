using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	//public int[] total;
	public int max;
    public int screenLimit;
	private int maxEnemies = 20;
	public movement enemy0;
	public movement enemy1;
	public movement enemy2;
	public movement enemy3;
	private GameObject[] enemyList0 = new GameObject[20];
	private GameObject[] enemyList1 = new GameObject[20];
	private GameObject[] enemyList2 = new GameObject[20];
	private GameObject[] enemyList3 = new GameObject[20];

	public double delay0;
	public double delay1;
	public double delay2;
	public double delay3;
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

    // Use this for initialization
    void Start (){
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
	
	// Update is called once per frame
	void Update () {
		if (Time.time > delay0 && Time.time > nextTime0 && spawns0 < max && num0 < screenLimit) {
			nextTime0 = Time.time + spawnTime0;
			GameObject temp = enemyList0 [num0];
			temp.transform.position = new Vector3(enemy0.startPosX, enemy0.startPosY, 0);
            temp.transform.localScale.Scale(new Vector3(2, 2, 1));
            temp.gameObject.SetActive (true);
			num0 += 1;
            spawns0 += 1;
		}
		if (Time.time > delay1 && Time.time > nextTime1 && spawns1 < max && num1 < screenLimit) {
			nextTime1 = Time.time + spawnTime1;
			GameObject temp = enemyList1 [num1];
			temp.transform.position = new Vector3 (enemy1.startPosX, enemy1.startPosY, 0);
			temp.gameObject.SetActive (true);
			num1 += 1;
            spawns1 += 1;
		}

		if (Time.time > delay2 && Time.time > nextTime2 && spawns2 < max && num2 < screenLimit) {
			nextTime2 = Time.time + spawnTime2;
			GameObject temp = enemyList2 [num2];
			temp.transform.position = new Vector3 (enemy2.startPosX, enemy2.startPosY, 0);
			temp.gameObject.SetActive (true);
			num2 += 1;
            spawns2 += 1;
		}

		if (Time.time > delay3 && Time.time > nextTime3 && spawns3 < max && num3 < screenLimit) {
			nextTime3 = Time.time + spawnTime3;
			GameObject temp = enemyList3 [num3];
			temp.transform.position = new Vector3 (enemy3.startPosX, enemy3.startPosY, 0);
			temp.gameObject.SetActive (true);
			num3 += 1;
            spawns3 += 1;
		}
	}
}