using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager instance;

	[SerializeField] private GameObject[] m_strikeFills;

	[SerializeField] private Text m_scoreLabel;
	[SerializeField] private Text m_highScoreLabel;

	void Awake()
	{
		instance = this;
	}

	void Start()
	{
		setHighscoreLabel();
	}

	public void updateStrikeFills(int p_currentStrike)
	{
		m_strikeFills[p_currentStrike].SetActive(true);
	}

	public void updateScoreLabel()
	{
		if(m_scoreLabel == null) Debug.LogError("m_scoreLabel is null");

		m_scoreLabel.text = GameplayManager.instance.score.ToString();
	}

	private void setHighscoreLabel()
	{
		m_highScoreLabel.text = PlayerPrefs.GetInt("HIGH_SCORE", 0).ToString();
	}
}
