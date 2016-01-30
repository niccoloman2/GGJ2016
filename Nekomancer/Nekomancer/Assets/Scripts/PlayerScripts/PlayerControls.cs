using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	private PlayerAnimationControl m_animationControl;

	private enum ThrowDirection
	{
		LEFT, RIGHT
	};
	
	private PlayerThrowRange m_playerThrowRange;

	void Awake()
	{
		m_playerThrowRange = GetComponentInChildren<PlayerThrowRange>();
		m_animationControl = GetComponent<PlayerAnimationControl>();
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

		if(!l_targetIngredient.bIsThrowable) return;

		SFXController.instance.playWhooshSFX();

		int l_directionModifier = (p_direction == ThrowDirection.LEFT) ? -1 : 1;

		l_targetIngredient.GetComponent<Rigidbody2D>().AddForce(new Vector2(l_directionModifier * 400, 1000)); //arbritrary numbers

		l_targetIngredient.bIsThrowable = false;
		l_targetIngredient = null;
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
		{
			//Debug.Log ("Left key pressed");
			m_animationControl.playLeftThrowAnimation();
			throwIngredient(ThrowDirection.LEFT);
		}

		if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
		{
			//Debug.Log ("Right key pressed");
			m_animationControl.playRightThrowAnimation();
			throwIngredient(ThrowDirection.RIGHT);
		}
	}
}
