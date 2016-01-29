using UnityEngine;
using System.Collections;

public class Ingredient : MonoBehaviour {

	private bool m_bisActive; //if object is visible and on-screen
	public	bool bIsActive
	{
		get
		{
			return m_bisActive;
		}
	}


	public bool bIsThrowable; //if object can be flung/thrown. If it is in range.

	private Vector3 m_startingPosition;

	void Awake()
	{
		m_startingPosition = new Vector3(0, 6, 0);

		deactivate();
	}

	public void activate()
	{
		Debug.Log ("Item activated");

		this.gameObject.SetActive(true);

		bIsThrowable	= false;

		m_bisActive		= true;
	}

	public void deactivate()
	{
		//Debug.Log ("Item deactivated");

		this.gameObject.SetActive(false);

		this.transform.position = m_startingPosition;

		bIsThrowable	= false;

		m_bisActive		= false;
	}
}
