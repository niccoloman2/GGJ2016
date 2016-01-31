using UnityEngine;
using System.Collections;

public class SFXController : MonoBehaviour {

	public static SFXController instance;

	private AudioSource m_audioSource;

	[SerializeField] private AudioClip m_whooshClip;
	[SerializeField] private AudioClip m_scoreClip;
	[SerializeField] private AudioClip m_missClip;
	[SerializeField] private AudioClip m_gameOverJingle;

	void Awake()
	{
		instance = this;

		m_audioSource = GetComponent<AudioSource>();
	}

	public void playWhooshSFX()
	{
		m_audioSource.PlayOneShot(m_whooshClip);
	}

	public void playScoreSFX()
	{
		m_audioSource.PlayOneShot(m_scoreClip);
	}

	public void playMissSFX()
	{
		m_audioSource.PlayOneShot(m_missClip);
	}

	public void playGameOverJingle()
	{
		m_audioSource.PlayOneShot(m_gameOverJingle);
	}

}
