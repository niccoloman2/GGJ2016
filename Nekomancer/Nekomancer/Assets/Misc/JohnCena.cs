using UnityEngine;
using System.Collections;

public class JohnCena : MonoBehaviour {

	bool m_bSkippable;
	float seconds;

	void Start()
	{
		seconds = 0f;
		m_bSkippable = false;

	}
	// Update is called once per frame
	void Update () {

		if(m_bSkippable)
		{
			if(Input.anyKeyDown)
			{
				Application.LoadLevel("Title");
			}
		}
		else
		{
			seconds += Time.deltaTime;

			if(seconds >= 1f)
			{
				m_bSkippable = true;
			}
		}
	
	}
}
