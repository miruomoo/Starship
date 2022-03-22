using UnityEngine;
using System.Collections;

public class Enemy1 : Enemy
{
	//# seconds for a full sine wave
	public float waveFrequency = 2;

	//sine wave
	public float width = 8;

	private float x0 = -12345; //The initial x value of pos
	private float birthTime;

	void Start()
	{
		x0 = pos.x;
		birthTime = Time.time;
	}
	
	public override void Move()
	{
		Vector3 tempPos = pos;

		float age = Time.time - birthTime;
		float theta = Mathf.PI * 2 * age / waveFrequency;
		float sin = Mathf.Sin(theta);
		tempPos.x = x0 + width * sin;
		pos = tempPos;

		base.Move();
	}
}