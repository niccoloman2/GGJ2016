using UnityEngine;
using System.Collections;

public class PlayerThrowRange : MonoBehaviour {

	private Ingredient m_ingredientInRange;
	public	Ingredient currentIngredient
	{
		get
		{
			return m_ingredientInRange;
		}
	}

	void OnTriggerEnter2D(Collider2D p_col)
	{
		Ingredient l_ingredient = p_col.GetComponent<Ingredient>();

		if(p_col != null)
		{
			l_ingredient.bIsThrowable	= true;
			m_ingredientInRange			= l_ingredient;
		}
	}

	void OnTriggerStay2D(Collider2D p_col)
	{
		Ingredient l_ingredient = p_col.GetComponent<Ingredient>();
		
		if(p_col != null)
		{
			if(l_ingredient.bIsThrowable)
			{
				m_ingredientInRange			= l_ingredient;
			}
		}
	}

	void OnTriggerExit2D(Collider2D p_col)
	{
		Ingredient l_ingredient = p_col.GetComponent<Ingredient>();
		
		if(p_col != null)
		{
			l_ingredient.bIsThrowable	= false;
			m_ingredientInRange 		= null;
		}
	}
}
