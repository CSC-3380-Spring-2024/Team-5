using Godot;
using System;
using System.Collections.Generic;
public partial class obstacleSpawner : spawner
{
	public override void _Ready(){
		base._Ready();
		setEntity((PackedScene)ResourceLoader.Load("res://Scenes/terrain.tscn"),120);
		spawnEntities(15); 
	}
	 protected override bool isValidEntity(Vector2 newPos){
		return base.isValidEntity(newPos);

	}
}
