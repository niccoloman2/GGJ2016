using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	private enum ThrowDirection
	{
		LEFT, RIGHT
	};

	public Ingredient sampleIngredient;

	private PlayerThrowRange m_playerThrowRange;

	void Awake()
	{
		m_playerThrowRange = GetComponentInChildren<PlayerThrowRange>();
	}

	void throwIngredient(ThrowDirection p_direction)
	{
		if(m_playerThrowRange == null)
		{
			Debug.LogError("m_playerThrowRange is null");
			return;
		}

		Ingredient l_targetIngredient = m_playerThrowRange.currentIngredient;

		if(l_targetIngredient == null)
		{
			Debug.Log ("No target ingredient in range");
			return;
		}

		int l_directionModifier = (p_direction == ThrowDirection.LEFT) ? -1 : 1;

		l_targetIngredient.GetComponent<Rigidbody2D>().AddForce(new Vector2(l_directionModifier * 400, 1000));
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
		{
			Debug.Log ("Left key pressed");
			throwIngredient(ThrowDirection.LEFT);
		}

		if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
		{
			Debug.Log ("Right key pressed");
			throwIngredient(ThrowDirection.RIGHT);
		}

		if(Input.GetKeyDown(KeyCode.Space) && sampleIngredient != null)
		{
			sampleIngredient.deactivate();
			sampleIngredient.activate();
		}
	
	}
}
