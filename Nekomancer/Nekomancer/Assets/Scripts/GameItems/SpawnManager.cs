using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

	public static SpawnManager instance;

	[SerializeField] private Ingredient m_ingredientPrefab;
	[SerializeField] private Ingredient m_garbagePrefab;
	private List<Ingredient> m_ingredientPool;

	void Awake()
	{
		if(instance)
		{
			Destroy (this.gameObject);
		}

		instance = this;

		initializeIngredientPool();
	}

	void Start()
	{
		spawnWave();
	}

	void initializeIngredientPool()
	{
		int initialPoolSize = 10;

		int garbageCount	= 0;
		int goodCount		= 0;

		m_ingredientPool = new List<Ingredient>();

		for(int i = 0; i < initialPoolSize; i++)
		{
			Ingredient l_newIngredient;

			if(garbageCount >= 5)
			{
				l_newIngredient = Instantiate<Ingredient>(m_ingredientPrefab);
			}
			else if(goodCount >= 5)
			{
				l_newIngredient = Instantiate<Ingredient>(m_garbagePrefab);
			}
			else
			{
				l_newIngredient = (Random.Range(0, 100) > 49) ? Instantiate<Ingredient>(m_ingredientPrefab) : Instantiate<Ingredient>(m_garbagePrefab);
			}

			if(l_newIngredient.bIsGoodIngredient)
			{
				goodCount++;
			}
			else
			{
				garbageCount++;
			}

			m_ingredientPool.Add(l_newIngredient);
		}
	}

	Ingredient getInactiveIngredient()
	{
		Ingredient l_firstTry = m_ingredientPool[Random.Range(0, m_ingredientPool.Count)];

		if(!l_firstTry.bIsActive)
		{
			return l_firstTry;
		}

		for(int i = 0; i < m_ingredientPool.Count; i++)
		{
			if(!m_ingredientPool[i].bIsActive)
			{
				return m_ingredientPool[i];
			}
		}

		Ingredient l_newIngredient = (Random.Range(0, 100) > 49) ? Instantiate<Ingredient>(m_ingredientPrefab) : Instantiate<Ingredient>(m_garbagePrefab);
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

	private float getMinimumSpawnTime()
	{
		if(GameplayManager.instance.timeElapsed >= 60f)
		{
			return 0.1f;
		}
		if(GameplayManager.instance.timeElapsed >= 35f)
		{
			return 0.25f;
		}

		else if(GameplayManager.instance.timeElapsed >= 20f)
		{
			return 0.5f;
		}

		else if(GameplayManager.instance.timeElapsed >= 10f)
		{
			return 0.75f;
		}

		else
		{
			return 1.25f;
		}
	}

	private float getMaximumSpawnTime()
	{
		if(GameplayManager.instance.timeElapsed >= 60f)
		{
			return 0.2f;
		}
		if(GameplayManager.instance.timeElapsed >= 35f)
		{
			return 0.5f;
		}
		
		else if(GameplayManager.instance.timeElapsed >= 20f)
		{
			return 1f;
		}

		else if(GameplayManager.instance.timeElapsed >= 10f)
		{
			return 1.5f;
		}
		
		else
		{
			return 2f;
		}
	}

	IEnumerator spawnWaveCoroutine()
	{
		while(!GameplayManager.instance.bIsGameOver)
		{
			yield return new WaitForSeconds(Random.Range (getMinimumSpawnTime(), getMaximumSpawnTime()) ); //Take note. 0.25f is the fastest spawn time we can have.

			if(!GameplayManager.instance.bIsGameOver)
				spawnIngredient();

			yield return null;
		}


		yield return null;
	}

	public void deactivateAllObjects()
	{
		StopCoroutine(spawnWaveCoroutine());

		for(int i = 0; i < m_ingredientPool.Count; i ++)
		{
			m_ingredientPool[i].deactivate();
		}
	}

}
