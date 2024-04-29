using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class level1Gen : proc_gen
{
	
	private Vector2I dirtAtlas= new Vector2I(3,2);
	private Vector2I seaweedAtlas=new Vector2I(10,3);
	private Vector2I grassAtlas=new Vector2I(4,2);

	public override void _Ready()
	{
		base._Ready();
		GenerateLevel(50,100, dirtAtlas, seaweedAtlas, grassAtlas);
	}

	public override void _Process(double delta)
	{
	}

	
}
