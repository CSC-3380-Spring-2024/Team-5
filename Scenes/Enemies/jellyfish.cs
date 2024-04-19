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
