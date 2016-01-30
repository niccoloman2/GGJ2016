using UnityEngine;
using System.Collections;

public class GameplayManager : MonoBehaviour {

	public static GameplayManager instance;

	private int m_numberOfLives;

	private float m_timeElapsed;
	public	float timeElapsed
	{
		get
		{
			return m_timeElapsed;
		}
	}

	private bool m_bIsGameOver;
	public	bool bIsGameOver
	{
		get
		{
			return m_bIsGameOver;
		}
	}

	private int m_score;
	public	int score
	{
		get
		{
			return m_score;
		}
	}
	private int m_streak;
	private int m_scoreMultiplier;

	void Awake()
	{
		if(instance)
		{
			Destroy (this.gameObject);
		}

		instance = this;

		m_numberOfLives		= 3;
		m_timeElapsed		= 0f;
		m_score				= 0;
		m_streak			= 0;
		m_scoreMultiplier	= 1;
		m_bIsGameOver		= false;
	}

	public void addScore()
	{
		m_score += 5 * m_scoreMultiplier;
		UIManager.instance.updateScoreLabel();
	}

	public void goodStreak()
	{
		m_streak++;

		m_scoreMultiplier = 1 + (m_streak/10);
	}

	public void breakStreak()
	{
		m_streak 		  = 0;
		m_scoreMultiplier = 1;
	}

	public void strikePenalty()
	{
		m_numberOfLives--;

		if(m_numberOfLives <= 0)
		{
			m_numberOfLives = 0;

			m_bIsGameOver	= true;

			SpawnManager.instance.deactivateAllObjects();

			BGMController.instance.stopBGM();

			Debug.Log ("Game Over");
		}

		UIManager.instance.updateStrikeFills(m_numberOfLives);
	}

	void FixedUpdate()
	{
		m_timeElapsed += Time.fixedDeltaTime;
	}

}
