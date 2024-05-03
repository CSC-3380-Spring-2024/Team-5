using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class level1Gen : proc_gen
{
	public override void _Ready()
	{
		Width=50;
		Height=100;
		Tile1=new Vector2I(3,2);
		Tile2=new Vector2I(10,3);
		Tile3=new Vector2I(4,2);
		base._Ready();
		GenerateLevel(Width,Height, Tile1, Tile2, Tile3);
	}
	public override void _Process(double delta)
	{
	}

	
}
