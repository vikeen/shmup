﻿using UnityEngine;
using System.Collections;

public class SpecialEffectsHelper : MonoBehaviour {
	public static SpecialEffectsHelper Instance;
	
	public ParticleSystem smokeEffect;
	public ParticleSystem fireEffect;
	
	void Awake() {
		// Register the singleton
		if (Instance != null) {
			Debug.LogError("Multiple instances of SpecialEffectsHelper!");
		}
		
		Instance = this;
	}
	
	public void Explosion(Vector3 position) {
		instantiate(smokeEffect, position);
		instantiate(fireEffect, position);
	}
	
	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position) {
		ParticleSystem newParticleSystem = Instantiate(
			prefab,
			position,
			Quaternion.identity
			) as ParticleSystem;
		
		// Make sure it will be destroyed
		Destroy(
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
			);
		
		return newParticleSystem;
	}
}