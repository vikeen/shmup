using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public int points = 100;

	private bool hasSpawn;
	private MoveScript moveScript;
	private WeaponScript[] weapons;
	
	void Awake() {
		// Retrieve the weapon only once
		weapons = GetComponentsInChildren<WeaponScript>();
		
		// Retrieve scripts to disable when not spawn
		moveScript = GetComponent<MoveScript>();
	}
	
	// 1 - Disable everything
	void Start() {
		hasSpawn = false;
		
		collider2D.enabled = false;
		moveScript.enabled = false;

		foreach (WeaponScript weapon in weapons) {
			weapon.enabled = false;
		}
	}
	
	void Update() {
		if (hasSpawn == false) {
			if (renderer.IsVisibleFrom(Camera.main)) {
				Spawn();
			}
		} else {
			foreach (WeaponScript weapon in weapons) {
				if (weapon != null && weapon.enabled && weapon.CanAttack) {
					weapon.Attack(true);
				}
			}
			
			if (renderer.IsVisibleFrom(Camera.main) == false) {
				Destroy(gameObject);
			}
		}
	}
	
	// 3 - Activate itself.
	private void Spawn() {
		hasSpawn = true;
		
		collider2D.enabled = true;
		moveScript.enabled = true;

		foreach (WeaponScript weapon in weapons) {
			weapon.enabled = true;
		}
	}
}