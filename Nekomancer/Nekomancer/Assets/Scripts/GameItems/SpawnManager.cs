using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

	[SerializeField] private Ingredient m_ingredientPrefab;
	private List<Ingredient> m_ingredientPool;

	void Awake()
	{
		initializeIngredientPool();
	}

	void Start()
	{
		spawnWave();
	}

	void initializeIngredientPool()
	{
		int initialPoolSize = 10;

		m_ingredientPool = new List<Ingredient>();

		for(int i = 0; i < initialPoolSize; i++)
		{
			Ingredient l_newIngredient = Instantiate<Ingredient>(m_ingredientPrefab);

			m_ingredientPool.Add(l_newIngredient);
		}
	}

	Ingredient getInactiveIngredient()
	{
		for(int i = 0; i < m_ingredientPool.Count; i++)
		{
			if(!m_ingredientPool[i].bIsActive)
			{
				return m_ingredientPool[i];
			}
		}

		Ingredient l_newIngredient = Instantiate<Ingredient>(m_ingredientPrefab);
		m_ingredientPool.Add (l_newIngredient);

		return l_newIngredient;
	}

	public void spawnIngredient()
	{
		getInactiveIngredient().activate();
	}

	public void spawnWave()
	{
		StartCoroutine(spawnWaveCoroutine());
	}

	IEnumerator spawnWaveCoroutine()
	{
		int ingredientNumber = 30;
		int ingredientsSpawned = 0;

		while(ingredientsSpawned < ingredientNumber)
		{
			yield return new WaitForSeconds(1f); //Take note. 0.25f is the fastest spawn time we can have.

			spawnIngredient();

			ingredientsSpawned++;

			yield return null;
		}


		yield return null;
	}

}
