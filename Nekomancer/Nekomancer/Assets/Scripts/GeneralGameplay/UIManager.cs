using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager instance;

	[SerializeField] private Image[] m_strikeFills;

	void Awake()
	{
		instance = this;
	}

	public void updateStrikeFills(int p_currentStrike)
	{
		m_strikeFills[p_currentStrike].gameObject.SetActive(true);
	}
}
