using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
	public string ID;
	public string SkillName;
	public float Cooldown;
	public Sprite Icon;

	public abstract void Activate(GameObject user);
}
