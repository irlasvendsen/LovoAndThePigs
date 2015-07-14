using UnityEngine;
using System.Collections;

public class Endurance : MonoBehaviour {

	public int maxEndurance = 10;
	public int endurance = 10;



	// Use this for initialization
	void Start () {

		endurance = maxEndurance;
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void TakeDamage(int damage)
	{
		endurance -= damage;

		if (endurance <=0)
		{
			BlowDown();

		}
	}

	void BlowDown()
	{
		Destroy (gameObject);
	}
}
