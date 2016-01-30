using UnityEngine;
using System.Collections;

public class PortalChecker : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D p_col)
	{
		Ingredient l_ingredient = p_col.GetComponent<Ingredient>();

		if(l_ingredient != null)
		{
			if(l_ingredient.bIsGoodIngredient)
			{
				Debug.Log ("Score!");
			}
			else
			{
				Debug.Log ("Penalty!");
				GameplayManager.instance.strikePenalty();
			}

			l_ingredient.deactivate();
		}
	}
}
