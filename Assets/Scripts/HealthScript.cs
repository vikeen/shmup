using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int health = 2;
	public bool isEnemy = true;

	void OnTriggerEnter2D(Collider2D collider) {
		ShotScript shot = collider.gameObject.GetComponent<ShotScript>();

		if (shot != null) {
			if (shot.isEnemyShot != isEnemy) {
				health -= shot.damage;
			}

			Destroy(shot.gameObject);

			if (health <= 0) {
				SpecialEffectsHelper.Instance.Explosion(transform.position);

				if (isEnemy) {
					ScoreBoardHelper.Instance.increaseScore(gameObject.GetComponent<EnemyScript>().points);
				}

				Destroy(gameObject);
			}
		}
	}
}