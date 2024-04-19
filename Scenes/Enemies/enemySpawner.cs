using Godot;
using System;
using System.Collections.Generic;
public partial class enemySpawner : spawner
{
	public override void _Ready(){
		base._Ready();
		setEntity((PackedScene)ResourceLoader.Load("res://Scenes/Enemies/jellyfish.tscn"),200);
		spawnEntities(15); 
	}
	 protected override bool isValidEntity(Vector2 newPos){
		return base.isValidEntity(newPos);

	}
}