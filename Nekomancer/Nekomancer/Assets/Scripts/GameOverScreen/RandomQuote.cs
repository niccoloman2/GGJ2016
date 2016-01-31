using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomQuote : MonoBehaviour {

	private Text m_quoteText;
	private string[] quoteArray;

	public int quoteID;

	void Start()
	{
		m_quoteText = GetComponent<Text>();

		quoteArray = new string[]{"\"It's not you. It's me.\"",
			"\"The elder gods are on vacation leave.\"",
			"Credits: Niccolo Manahan, Renzo Hippolito, Ann Galit",
			"\"Try out Aeon too! By Team Titann!\"",
			"\"Try Typecast! By Team Type na Type!\"",
			"\"Try My Monster Ex! By Forever Alone!\"",
			"\"I actually slept during the game jam.\"",
			"\"But I wanna beat the highscore!\"",
			"\"Seriously. This is a good game.\"",
			"\"No cats were (physically) harmed in the making of this game.\"",
			"\"Nekomancers practice nekomancy. The magic of d'awwww.\"",
			"\"Never confuse a nekomancer with a necromancer. They hate that.\"",
			"\"Nekomancers are NOT the same as nyancerors. It's a different art.\"",
			"\"AND HIS NAME IS JOHN CENA!\"",
			"\"Never buy your mana orbs in installment.\""};

		quoteID = Random.Range(0, quoteArray.Length);

		m_quoteText.text = quoteArray[quoteID];
	}
}
