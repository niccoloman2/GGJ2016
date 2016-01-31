using UnityEngine;
using System.Collections;

public class GarbageChecker : MonoBehaviour {

	[SerializeField] private ParticleSystem m_catchParticles;

	void OnTriggerEnter2D(Collider2D p_col)
	{
		Ingredient l_ingredient = p_col.GetComponent<Ingredient>();
		
		if(l_ingredient != null)
		{
			m_catchParticles.Play();

			if(l_ingredient.bIsGoodIngredient)
			{
				Debug.Log ("Waste!");
				ScreenFlasher.instance.flashScreen(Color.red);
				GameplayManager.instance.strikePenalty();
				GameplayManager.instance.breakStreak();
			}
			else
			{
				Debug.Log ("Score!");
				//ScreenFlasher.instance.flashScreen(Color.white);
				GameplayManager.instance.addScore();
				GameplayManager.instance.goodStreak();
			}
			
			l_ingredient.deactivate();
		}
	}
}
