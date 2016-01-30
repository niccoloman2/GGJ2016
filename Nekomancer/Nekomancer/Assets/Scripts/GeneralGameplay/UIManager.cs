using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager instance;

	[SerializeField] private Image[] m_strikeFills;

	[SerializeField] private Text m_scoreLabel;

	void Awake()
	{
		instance = this;
	}

	public void updateStrikeFills(int p_currentStrike)
	{
		m_strikeFills[p_currentStrike].gameObject.SetActive(true);
	}

	public void updateScoreLabel()
	{
		if(m_scoreLabel == null) Debug.LogError("m_scoreLabel is null");

		m_scoreLabel.text = GameplayManager.instance.score.ToString();
	}
}
