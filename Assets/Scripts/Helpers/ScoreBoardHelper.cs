using UnityEngine;
using System.Collections;

public class ScoreBoardHelper : MonoBehaviour {
	public int playerScore = 0;
	public GUIElement scoreBoard;

	public static ScoreBoardHelper Instance;

	void Awake() {
		if (Instance != null) {
			Debug.LogError("Multiple instances of SpecialEffectsHelper!");
		}
		
		Instance = this;
	}

	private int getScore() {
		return playerScore;
	}

	public void increaseScore(int amount){
		playerScore += amount;
		updateScore();
	}

	private void updateScore() {
		scoreBoard.guiText.text = "Score: " + ((int)playerScore).ToString();
	}
}
