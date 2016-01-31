﻿using UnityEngine;
using System.Collections;

public class PlayerAnimationControl : MonoBehaviour {

	private Animator m_animator;

	void Awake()
	{
		m_animator = GetComponentInChildren<Animator>();
	}

	public void playLeftThrowAnimation()
	{
		m_animator.Play("ThrowLeft");
	}

	public void playRightThrowAnimation()
	{
		m_animator.Play("ThrowRight");
	}

	public void playMissAnimation()
	{
		m_animator.Play("Miss");
	}

	public void playOverAnimation()
	{
		m_animator.Play("Over");
	}
}
