using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreenController : MonoBehaviour {

	[SerializeField] private Image m_fadeOverlay;

	[SerializeField] private AudioSource m_meowSource;

	public void startTheGame()
	{
		m_meowSource.Play();
		StartCoroutine(startGameCoroutine());
	}

	IEnumerator startGameCoroutine()
	{
		Color faderColor = m_fadeOverlay.color;
		float faderAlpha = faderColor.a;

		while(faderAlpha < 1)
		{
			Color newFaderColor = faderColor;
			faderAlpha += Time.deltaTime;
			newFaderColor.a = faderAlpha;

			m_fadeOverlay.color = newFaderColor;

			yield return null;
		}

		Application.LoadLevel("Game");

		yield return null;
	}

	public void toTutorial()
	{
		m_meowSource.Play();
		StartCoroutine(tutorialCoroutine());
	}

	IEnumerator tutorialCoroutine()
	{
		Color faderColor = m_fadeOverlay.color;
		float faderAlpha = faderColor.a;
		
		while(faderAlpha < 1)
		{
			Color newFaderColor = faderColor;
			faderAlpha += Time.deltaTime;
			newFaderColor.a = faderAlpha;
			
			m_fadeOverlay.color = newFaderColor;
			
			yield return null;
		}
		
		Application.LoadLevel("Tutorial");
		
		yield return null;
	}
}
