using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	public Transform shotPrefab;
	public float shootingRate = 0.25f;

	private float shootCooldown;
	
	void Start() {
		shootCooldown = 0f;
	}
	
	void Update() {
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}
	}
	
	public void Attack(bool isEnemy) {
		if (CanAttack) {
			shootCooldown = shootingRate;
			
			var shotTransform = Instantiate(shotPrefab) as Transform;
			shotTransform.position = transform.position;
			
			// The is enemy property
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null) {
				shot.isEnemyShot = isEnemy;
			}
			
			// Make the weapon shot always towards it
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null) {
				move.direction = this.transform.right; // towards in 2D space is the right of the sprite
			}
		}
	}
	
	public bool CanAttack {
		get {
			return shootCooldown <= 0f;
		}
	}
}