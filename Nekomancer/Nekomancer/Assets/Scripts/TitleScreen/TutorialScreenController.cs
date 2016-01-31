using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialScreenController : MonoBehaviour {

	[SerializeField] private Image m_fadeOverlay;

	void Start()
	{
		StartCoroutine(fadeOutFader());
	}

	IEnumerator fadeOutFader()
	{
		Color faderColor = m_fadeOverlay.color;
		float faderAlpha = faderColor.a;
		
		while(faderAlpha > 0f)
		{
			Color newFaderColor = faderColor;
			faderAlpha -= Time.deltaTime;
			newFaderColor.a = faderAlpha;
			
			m_fadeOverlay.color = newFaderColor;
			
			yield return null;
		}
	}
	
	public void startTheGame()
	{
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
}
