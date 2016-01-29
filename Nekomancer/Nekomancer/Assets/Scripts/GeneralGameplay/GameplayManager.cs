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

	void Awake()
	{
		if(instance)
		{
			Destroy (this.gameObject);
		}

		instance = this;

		m_numberOfLives		= 3;
		m_timeElapsed		= 0f;
	}

	public void strikePenalty()
	{
		m_numberOfLives--;

		if(m_numberOfLives <= 0)
		{
			m_numberOfLives = 0;

			Debug.Log ("Game Over");
		}
	}

	void FixedUpdate()
	{
		m_timeElapsed += Time.fixedDeltaTime;
	}

}
