﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour 
{
	[SerializeField]
	private GameObject[] _PowerupPool;
	[SerializeField]
	private Transform[] _PowerupSpawnPoints;
	[SerializeField]
	private int _MaximumNumberOfPowerupsAtATime;
	
	private void Update () 
	{
		if (Powerup.SpawnedPowerups != null && Powerup.SpawnedPowerups.Count < _MaximumNumberOfPowerupsAtATime)
		{
			Transform chosenSpawnPoint = _PowerupSpawnPoints[Random.Range(0, _PowerupSpawnPoints.Length)];
			bool canSpawnAtPoint = false;
			while (!canSpawnAtPoint)
			{
				chosenSpawnPoint = _PowerupSpawnPoints[Random.Range(0, _PowerupSpawnPoints.Length)];
				RaycastHit raycastHit;
				Collider[] colliders = Physics.OverlapBox(chosenSpawnPoint.transform.position,new Vector3 (0.5f, 1.5f, 0.5f));
				
				canSpawnAtPoint = true;
				foreach (var collider in colliders)
				{
					if (collider.GetComponent<Powerup>() != null || collider.GetComponent<Pickup>() != null || collider.GetComponent<PlayerController>() != null)
					{
						canSpawnAtPoint = false;
					}
				}
			}
			SpawnPowerup(chosenSpawnPoint);
		}
	}

	public void SpawnPowerup(Transform chosenSpawnPoint)
	{
		GameObject chosenPowerup = _PowerupPool[Random.Range(0, _PowerupPool.Length)];
		Instantiate(chosenPowerup, chosenSpawnPoint.position, chosenPowerup.transform.rotation);
	}
}