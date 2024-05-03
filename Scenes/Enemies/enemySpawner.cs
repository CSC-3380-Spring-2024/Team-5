using Godot;
using System;
using System.Collections.Generic;
public partial class enemySpawner : spawner
{
	Color[] colors = new Color[] {
	new Color(0, 1, 0),      
	new Color(0, 1, 1),      
	new Color(0, 0.5f, 1),   
};
	
	public override void _Ready(){
		base._Ready();
		setEntity((PackedScene)ResourceLoader.Load("res://Scenes/Enemies/jellyfish.tscn"),220);
		int totalEnemies = 20 + (5); 
		spawnEntities(20,colors,"jellyfishSprite"); 
	}
	 protected override bool isValidEntity(Vector2 newPos, float effectiveRadius){
		return base.isValidEntity(newPos,effectiveRadius);
	}
}
