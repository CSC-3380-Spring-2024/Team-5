using Godot;
using System;
using System.Collections.Generic;

public partial class spawner : Node2D
{	
private  PackedScene entityScene;
private PackedScene playerScene;
private Node2D player;
private Random random = new Random();
private float minX = -2000;
private float maxX = 2000;
private float minY = -700;
private float maxY = 1000;
private float entityRadius;

private List<Vector2>spawnPositions=new List<Vector2>();
	public override void _Ready()
	{
		playerScene=(PackedScene)ResourceLoader.Load("res://Scenes/Player/player.tscn");
		player=(Node2D)playerScene.Instantiate();
	}

	public void setEntity(PackedScene entityScene, float entityRadius){
		this.entityScene=entityScene;
		this.entityRadius=entityRadius;
	}

	 protected void spawnEntities(int numEntities,Color[]colors,string sprite)
	{
		spawnPositions.Clear();
		for (int i = 0; i < numEntities; i++)
		{
			Vector2 randomPos;
			float randomScale;
			bool posValid=false;
			do{
			float randomX = (float)random.NextDouble() * (maxX - minX) + minX;
			float randomY = (float)random.NextDouble() * (maxY - minY) + minY;
			randomPos = new Vector2(randomX, randomY);
			randomScale=(float)random.NextDouble()*(float)(0.9-0.2)+(float)0.8;
			float effectiveRadius = entityRadius * randomScale;
			posValid=isValidEntity(randomPos,effectiveRadius) && !isPlayerClose(randomPos);
			}
			while(!posValid);
			spawnPositions.Add(randomPos);
			Node2D entityInstance = (Node2D)entityScene.Instantiate();
			entityInstance.Position = randomPos;
			entityInstance.Scale=new Vector2(randomScale,randomScale);
			AnimatedSprite2D entitySprite=entityInstance.GetNode<Godot.AnimatedSprite2D>(sprite);
			if(entitySprite!=null){
				entitySprite.Modulate = Colors.White;
				int colorIndex = random.Next(0, colors.Length);
				entitySprite.Modulate *= colors[colorIndex];
			}
			AddChild(entityInstance);
		}
	}

	 protected void spawnEntities(int numEntities)
	{
		for (int i = 0; i < numEntities; i++)
		{
			Vector2 randomPos;
			float randomScale;
			bool posValid=false;
			do{
			float randomX = (float)random.NextDouble() * (maxX - minX) + minX;
			float randomY = (float)random.NextDouble() * (maxY - minY) + minY;
			randomPos = new Vector2(randomX, randomY);
			randomScale=(float)random.NextDouble()*(float)(0.9-0.2)+(float)0.8;
			float effectiveRadius=entityRadius * randomScale;
			posValid=isValidEntity(randomPos,effectiveRadius) && !isPlayerClose(randomPos);
			}
			while(!posValid);
			spawnPositions.Add(randomPos);
			Node2D entityInstance = (Node2D)entityScene.Instantiate();
			entityInstance.Position = randomPos;
			entityInstance.Scale=new Vector2(randomScale,randomScale);
			AddChild(entityInstance);
		}
	}

	protected virtual bool isValidEntity(Vector2 newPos,float effectiveRadius){
		foreach (Node child in GetChildren())
		{
			if (child is Node2D entity && newPos.DistanceTo(entity.Position) < effectiveRadius)
			{
				return false;
			}
		}
		return true;
	}

	private bool isPlayerClose(Vector2 newPos)
{
	
	if (player != null && player.Position != null)
	{
			if (ManhattanDistance(player.Position,newPos) < entityRadius * 3)
			{
				return true;
			}
		
	}
	return false;
}

	protected virtual float ManhattanDistance(Vector2 pointA, Vector2 pointB)
	{
		float deltaX = Math.Abs(pointA.X - pointB.X);
		float deltaY = Math.Abs(pointA.Y - pointB.Y);
		return deltaX + deltaY;
	}
}
