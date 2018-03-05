using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour 
{
	public Transform target;

	public int targetIndex;
	public Transform[] targets;

	public float smoothRotationSpeed;

	public float distanceFromTarget;

	// Use this for initialization
	void Start () 
	{
		
	}

	void LookAt()
	{
		target = targets[targetIndex];

		Vector3 targetDirection = target.position - this.transform.position;
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDirection), smoothRotationSpeed * Time.fixedDeltaTime);
	}

	void SwitchTarget()
	{
		if(Vector3.Distance(transform.position, target.position) <= distanceFromTarget)
		{
			targetIndex ++;
		}

		if(targetIndex >= targets.Length)
		{
			targetIndex = 0;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		LookAt();
		SwitchTarget();
	}
}
