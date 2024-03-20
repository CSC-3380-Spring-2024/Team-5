using Godot;
using System;


public partial class View : Camera2D
{
	int speed=500;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Area2D player=GetNode<Area2D>("../Player/Area2D");
		if(player !=null){
			GlobalPosition=player.GlobalPosition;
		}
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
		 public override void _PhysicsProcess(double delta)
	{
		 Vector2 arrowInput = new Vector2(
			Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left"),
			Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up")
		);
		Vector2 movement = new Vector2((float)(arrowInput.X * speed * delta),(float)(arrowInput.Y * speed * delta));
		Translate(movement);
	   
	}
}
