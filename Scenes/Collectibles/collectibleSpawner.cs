using Godot;
using System;
using System.Collections.Generic;
public partial class collectibleSpawner : spawner
{
	public override void _Ready(){
		base._Ready();
		setEntity((PackedScene)ResourceLoader.Load("res://Scenes/Collectibles/heart.tscn"),50);
		spawnEntities(5); 
		setEntity((PackedScene)ResourceLoader.Load("res://Scenes/Collectibles/seashell.tscn"),50);
		spawnEntities(5); 
	}
	 protected override bool isValidEntity(Vector2 newPos){
		return base.isValidEntity(newPos);

	}
}
