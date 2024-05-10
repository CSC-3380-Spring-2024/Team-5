using System;
using System.Runtime.CompilerServices;
using Godot;


public partial class jellyfish : CharacterBody2D
{
	private enum enemyState{
		Idle,
		Chase,
		Attack,
		Recover
	}
	private int speed = 150;
	private Node player = null;
	private bool playerChase = false;
	private enemyState currentState = enemyState.Idle;
	private AnimatedSprite2D enemySprite;
	private float recoveryTime = 0.5f;
	private float recoveryTimer = 0.0f;
	private bool isIdle=false;
	[Export] private float maxHealth = 200;
	private float health;
	private Vector2 lastDefeatedEnemyPosition = Vector2.Zero;
	private PackedScene experienceScene;
	private Node2D experienceOrbInstance;
	private PackedScene caveScene;
	private Node2D caveInstance;

	private enemyManager enemyManager;
	public override void _Ready()
	{
		GetNode<Godot.ProgressBar>("HealthBar").MaxValue=maxHealth;
		GetNode<Godot.ProgressBar>("HealthBar").Value=maxHealth;
		health = maxHealth;
		enemySprite=GetNode<Godot.AnimatedSprite2D>("jellyfishSprite");
		enemySprite.Play("idle");
		experienceScene=(PackedScene)ResourceLoader.Load("res://Scenes/Collectibles/experience_orb.tscn");
		experienceOrbInstance =(Node2D) experienceScene.Instantiate();
		caveScene=(PackedScene)ResourceLoader.Load("res://Scenes/Map/cave.tscn");
		caveInstance=(Node2D) caveScene.Instantiate();
		enemyManager=GetNode<enemyManager>("/root/EnemyManager");
		enemyManager.enemySpawned();
		
		
		
	}
	public override void _Process(double delta)
	{
		switch(currentState){
		 case enemyState.Idle:
				if (playerChase && player != null)
				{
					currentState = enemyState.Chase;
					enemySprite.Stop();
					enemySprite.Play("chase");
				}
				break;
			case enemyState.Chase:
				if (playerChase && player != null)
				{
					MoveTowardsPlayer(delta);
				}
				else
				{
					currentState = enemyState.Idle;
					enemySprite.Stop();
					enemySprite.Play("idle");
				}
				break;
			case enemyState.Attack:
				enemySprite.Play("attack");
				currentState = enemyState.Recover;
				recoveryTimer = recoveryTime;
				break;
			case enemyState.Recover:
			recoveryTimer -= (float)delta;
			if (recoveryTimer <= 0)
			{
				 currentState = enemyState.Chase;
				 enemySprite.Stop();
				 enemySprite.Play("chase");
			}
			break;
		}
	}

	 private void MoveTowardsPlayer(double delta)
	{
	 if (player is Area2D kinematicPlayer)
			{
				Vector2 direction = ((kinematicPlayer.GlobalPosition -GlobalPosition).Normalized())*speed * (float)delta;
				KinematicCollision2D enemyCollision=MoveAndCollide(direction);
				if(enemyCollision==null){
				GlobalPosition += direction;
				isIdle=false;
				}
			}
	}

	private void _on_detection_area_area_entered(Node body){
		if(body.IsInGroup("player")){
		player=body;
		playerChase=true;
		}
	}

	private void _on_detection_area_area_exited(Node body){
		if(body.IsInGroup("player")){
		player=null;
		playerChase=false;
		}
	}
	private void _on_enemy_hitbox_area_entered(Node body){
	 if (body.IsInGroup("player") && currentState != enemyState.Recover)
	{
		currentState = enemyState.Attack;
	}
}

	public void damage(float damageAmount){
		health -= damageAmount;
		GetNode<Godot.ProgressBar>("HealthBar").Value = health;
		lastDefeatedEnemyPosition = GlobalPosition;
		if(health <= 0){
			experienceOrbInstance.Position = lastDefeatedEnemyPosition;
			caveInstance.Position = lastDefeatedEnemyPosition;
			enemyManager.enemyKilled();
			QueueFree();
			lastDefeatedEnemyPosition = GlobalPosition;
			GetParent().AddChild(experienceOrbInstance);
			
			GD.Print(enemyManager.getNumEnemies());
			if(enemyManager.getNumEnemies()==0){
				caveInstance.Position = lastDefeatedEnemyPosition;
				GetParent().AddChild(caveInstance);
				
			}
			
		}
	}
	
	
}
