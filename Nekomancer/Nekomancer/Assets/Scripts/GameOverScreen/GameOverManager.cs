using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	[SerializeField] private Text m_scoreLabel;
	[SerializeField] private Text m_highScoreLabel;

	private bool m_bIsNewHighScore;

	[SerializeField] private Image m_fadeOverlay;

	[SerializeField] private GameObject m_newHighScoreIndicator;

	private bool m_bCanContinue;
	[SerializeField] private GameObject m_continueIndicator;

	public RandomQuote m_randomQuote;

	void Start()
	{
		m_bCanContinue			= false;

		m_scoreLabel.text 		= PlayerPrefs.GetInt("CURRENT_SCORE", 0).ToString();
		m_highScoreLabel.text	= PlayerPrefs.GetInt("HIGH_SCORE", 0).ToString();

		m_bIsNewHighScore	= (PlayerPrefs.GetInt("NEW_HIGH", 0) > 0) ? true : false;

		if(m_bIsNewHighScore)
		{
			m_newHighScoreIndicator.SetActive(true);
		}
		else
		{
			m_newHighScoreIndicator.SetActive(false);
		}

		Invoke("enableContinue", 2f);

		FadeScreenOut(0.5f);
	}

	void enableContinue()
	{
		m_bCanContinue = true;
		m_continueIndicator.SetActive(true);
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

	void Update()
	{
		if(Input.anyKeyDown)
		{
			if(m_bCanContinue)
			{
				if(m_randomQuote.quoteID == 13)
				{
					Application.LoadLevel("JohnCena");
				}
				else
				{
					Application.LoadLevel("Title");
				}
			}
		}
	}
}
