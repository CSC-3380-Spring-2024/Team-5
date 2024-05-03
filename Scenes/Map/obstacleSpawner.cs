using Godot;
using System;
using System.Collections.Generic;
public partial class obstacleSpawner : spawner
{
	Color[] colors = new Color[] {
	};
	public override void _Ready(){
		base._Ready();
		setEntity((PackedScene)ResourceLoader.Load("res://Scenes/terrain.tscn"),120);
		spawnEntities(1,colors,"Sprite2D"); 
	}
	 protected override bool isValidEntity(Vector2 newPos,float effectiveRadius){
		return base.isValidEntity(newPos,effectiveRadius);
	}
}
