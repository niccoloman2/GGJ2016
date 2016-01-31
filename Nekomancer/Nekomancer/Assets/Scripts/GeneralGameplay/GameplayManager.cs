using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

	[SerializeField] private Image m_fadeOverlay;

	[SerializeField] private GameObject m_player;
	private PlayerAnimationControl m_playerAnimationControl;

	[SerializeField] private ParticleSystem m_gameOverParticles;

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

		m_playerAnimationControl = m_player.GetComponent<PlayerAnimationControl>();
	}

	void Start()
	{
		FadeScreenOut(0.25f);
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
		if(m_numberOfLives > 0)
		{
			m_playerAnimationControl.playMissAnimation();
		}
		m_streak 		  = 0;
		m_scoreMultiplier = 1;
	}

	public void strikePenalty()
	{
		m_numberOfLives--;

		if(m_numberOfLives <= 0)
		{
			m_playerAnimationControl.playOverAnimation();

			m_numberOfLives = 0;

			m_bIsGameOver	= true;

			SpawnManager.instance.deactivateAllObjects();

			BGMController.instance.stopBGM();

			PlayerPrefs.SetInt("CURRENT_SCORE", m_score);

			if(m_score > PlayerPrefs.GetInt("HIGH_SCORE", 0))
			{
				Debug.Log ("New highscore!");
				PlayerPrefs.SetInt("HIGH_SCORE", m_score);
				PlayerPrefs.SetInt("NEW_HIGH", 1);
			}
			else
			{
				PlayerPrefs.SetInt("NEW_HIGH", 0);
			}

			Debug.Log ("Game Over");
			StartCoroutine(endGameCoroutine());
		}
		else
		{
			m_playerAnimationControl.playMissAnimation();
		}

		UIManager.instance.updateStrikeFills(m_numberOfLives);
	}

	IEnumerator endGameCoroutine()
	{
		yield return new WaitForSeconds(1f);
		m_gameOverParticles.Play();
		FadeScreenIn(2f);

		yield return new WaitForSeconds(5f);

		Application.LoadLevel("GameOver");
	}

	void FixedUpdate()
	{
		m_timeElapsed += Time.fixedDeltaTime;
	}

	public void FadeScreenOut(float p_duration)
	{
		StartCoroutine(fadeScreenOutCoroutine(p_duration));
	}

	IEnumerator fadeScreenOutCoroutine(float p_duration)
	{
		float timeElapsed 	= 0f;
		Color faderColor 	= m_fadeOverlay.color;
		float faderAlpha	= faderColor.a;

		while(timeElapsed < p_duration)
		{
			timeElapsed += Time.fixedDeltaTime;
			faderAlpha	= 1 - timeElapsed/p_duration;

			Color newFaderColor = faderColor;
			newFaderColor.a = faderAlpha;

			m_fadeOverlay.color = newFaderColor;

			yield return null;
		}
	}

	public void FadeScreenIn(float p_duration)
	{
		StartCoroutine(fadeScreenInCoroutine(p_duration));
	}
	
	IEnumerator fadeScreenInCoroutine(float p_duration)
	{
		float timeElapsed 	= 0f;
		Color faderColor 	= m_fadeOverlay.color;
		float faderAlpha	= faderColor.a;
		
		while(timeElapsed < p_duration)
		{
			timeElapsed += Time.fixedDeltaTime;
			faderAlpha	 = timeElapsed/p_duration;
			
			Color newFaderColor = Color.white;
			newFaderColor.a = faderAlpha;
			
			m_fadeOverlay.color = newFaderColor;
			
			yield return null;
		}
	}
}
