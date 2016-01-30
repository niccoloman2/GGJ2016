using UnityEngine;
using System.Collections;

public class BGMController : MonoBehaviour {

	public static BGMController instance;

	private AudioSource m_audioSource;

	void Awake()
	{
		instance = this;

		m_audioSource = GetComponent<AudioSource>();
	}

	public void stopBGM()
	{
		m_audioSource.Stop();
	}
}
