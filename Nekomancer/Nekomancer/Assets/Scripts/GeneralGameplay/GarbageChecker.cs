using UnityEngine;
using System.Collections;

public class GarbageChecker : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D p_col)
	{
		Ingredient l_ingredient = p_col.GetComponent<Ingredient>();
		
		if(l_ingredient != null)
		{
			if(l_ingredient.bIsGoodIngredient)
			{
				Debug.Log ("Waste!");
				GameplayManager.instance.strikePenalty();
				GameplayManager.instance.breakStreak();
			}
			else
			{
				Debug.Log ("Score!");
				GameplayManager.instance.addScore();
				GameplayManager.instance.goodStreak();
			}
			
			l_ingredient.deactivate();
		}
	}
}
