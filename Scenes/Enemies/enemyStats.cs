using System;
using System.Runtime.CompilerServices;
using Godot;

public partial class enemyStats : CharacterBody2D
{
	private ProgressBar healthBarScene;
	protected int health;
	protected int damage;

	public void takeDamage(int amount){
		health-=amount;
		if(health<=0){
			die();
		}

	}
	protected virtual void die(){
		QueueFree();
	}
}
