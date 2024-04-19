using System;
using System.Runtime.CompilerServices;
using Godot;

public partial class enemy : CharacterBody2D
{
	private int speed = 150;
	private Node player = null;
	private bool playerChase = false;
	private AnimatedSprite2D enemySprite;
	private bool isIdle=false;
	
	public override void _Ready()
	{
		enemySprite=GetNode<Godot.AnimatedSprite2D>("enemySprite");
		enemySprite.Play("idle");
		

	}
	public override void _Process(double delta)
	{
		
		
	}
   
	   public override void _PhysicsProcess(double delta){
	   
		
			if (playerChase && player != null) {
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
	}

	private void _on_detection_area_area_entered(Node body){
		if(body.IsInGroup("player")){
		player=body;
		playerChase=true;
		enemySprite.Stop();
		}
		
	}

	private void _on_detection_area_area_exited(Node body){
		if(body.IsInGroup("player")){
		player=null;
		playerChase=false;
		enemySprite.Play("idle");
		}
		
	
	}
}

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
	
	public override void _Ready()
	{
		enemySprite=GetNode<Godot.AnimatedSprite2D>("enemySprite");
		enemySprite.Play("idle");
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
	private void _on_enemy_hitbox_area_exited(Node body){
		if(body.IsInGroup("attack")){
			
		}

	
	}

	
}
