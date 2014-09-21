using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Vector2 speed = new Vector2(25, 25);
	private WeaponScript[] weapons;

	// Use this for initialization
	void Awake() {
		weapons = GetComponentsInChildren<WeaponScript>();
	}

	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

		movement *= Time.deltaTime;

		transform.Translate(movement);

		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");

		if (shoot) {
			foreach(WeaponScript weapon in weapons) {
				if (weapon != null && weapon.CanAttack) {
					weapon.Attack(false);
				}
			}
		}

		// 6 - Make sure we are not outside the camera bounds
		float dist = (transform.position - Camera.main.transform.position).z;
		
		float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
		float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
		float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);
	}
}
