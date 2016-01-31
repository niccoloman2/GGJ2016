using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScorePopups : MonoBehaviour {

	[SerializeField] private Text m_scorePopup;
	[SerializeField] private Text m_comboPopup;

	public void scorePopup(int p_scoreValue)
	{
		m_scorePopup.text = "+" + p_scoreValue.ToString();
		StartCoroutine(popUpText(m_scorePopup, 0.25f));
	}

	public void comboPopup(int p_comboValue)
	{
		m_comboPopup.text = "COMBO X" + p_comboValue.ToString();
		StartCoroutine(popUpText(m_comboPopup, 1f));
	}

	IEnumerator popUpText(Text p_text, float p_duration)
	{
		float scaleScale = 0f;
		float currentSeconds = 0f;

		while(scaleScale < 1f)
		{
			currentSeconds += Time.deltaTime;
			scaleScale = currentSeconds/(p_duration/2f);
			p_text.transform.localScale = Vector3.one * scaleScale;
			yield return null;
		}

		p_text.transform.localScale = Vector3.one;

		yield return new WaitForSeconds(p_duration/3f);

		while(scaleScale > 0f)
		{
			currentSeconds -= Time.deltaTime;
			scaleScale = currentSeconds/(p_duration/2f);
			p_text.transform.localScale = Vector3.one * scaleScale;
			yield return null;
		}

		p_text.transform.localScale = Vector3.zero;
	}
}
