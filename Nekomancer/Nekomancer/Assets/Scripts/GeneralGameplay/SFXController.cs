using UnityEngine;
using System.Collections;

public class SFXController : MonoBehaviour {

	public static SFXController instance;

	private AudioSource m_audioSource;

	[SerializeField] private AudioClip m_whooshClip;

	void Awake()
	{
		instance = this;

		m_audioSource = GetComponent<AudioSource>();
	}

	public void playWhooshSFX()
	{
		m_audioSource.PlayOneShot(m_whooshClip);
	}

}
