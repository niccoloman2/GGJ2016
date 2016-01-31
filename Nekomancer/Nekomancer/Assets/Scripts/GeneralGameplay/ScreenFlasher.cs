using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenFlasher : MonoBehaviour {

	public static ScreenFlasher instance;

	private Image m_faderImage;

	void Awake()
	{
		instance = this;

		m_faderImage = GetComponent<Image>();
	}

	public void flashScreen(Color p_color)
	{
		StartCoroutine(flashScreenCoroutine(p_color));
	}

	IEnumerator flashScreenCoroutine(Color p_color)
	{
		float fadeAlpha			= 0f;
		float currentSeconds	= 0f;

		while(fadeAlpha < 0.5f)
		{
			currentSeconds += Time.fixedDeltaTime;

			fadeAlpha = currentSeconds/0.05f;

			if(fadeAlpha > 0.5f)
			{
				fadeAlpha = 0.5f;
			}

			Color fadeInColor = p_color;
			fadeInColor.a = fadeAlpha;

			m_faderImage.color = fadeInColor;

			yield return null;
		}

		while(fadeAlpha > 0f)
		{
			currentSeconds += Time.fixedDeltaTime;
			
			fadeAlpha = 1f - currentSeconds/0.05f;
			
			Color fadeInColor = p_color;
			fadeInColor.a = fadeAlpha;
			
			m_faderImage.color = fadeInColor;
			
			yield return null;
		}

		yield return null;
	}
}
