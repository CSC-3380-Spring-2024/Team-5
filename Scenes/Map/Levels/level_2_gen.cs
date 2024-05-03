using Godot;
using System;

public partial class level_2_gen : proc_gen
{
	public override void _Ready()
	{
		Width=50;
		Height=200;
		Tile1=new Vector2I(3,1);
		Tile2=new Vector2I(3,4);
		Tile3=new Vector2I(4,1);
		base._Ready();
		GenerateLevel(Width,Height, Tile1, Tile2, Tile3);
	}

	public override void _Process(double delta)
	{
	}
}
