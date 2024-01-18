using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Stats
{
	[SerializeField]
	private int currentHealth;
	[SerializeField]
	private int maxHealth;
	[SerializeField]
	private int damage;
	[SerializeField]
	private float attackSpeed;

	public float AttackSpeed
	{
		get { return attackSpeed; }
		set { attackSpeed = value; }
	}


	public int Damage
	{
		get { return damage; }
		set { damage = value; }
	}


	public int MaxHealth
	{
		get { return maxHealth; }
		set { maxHealth = value; }
	}

	public int CurrentHealth
	{
		get { return currentHealth; }
		set { currentHealth = value; }
	}


}
