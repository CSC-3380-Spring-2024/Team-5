using Godot;
using System;
public partial class level_3_gen : proc_gen

{
	public override void _Ready()
	{
		Width=100;
		Height=100;
		Tile1=new Vector2I(6, 5);
		Tile2=new Vector2I(3, 4);
		base._Ready();
		GenerateLevel(Width,Height, Tile1, Tile2, Tile1);
	}

	public override void _Process(double delta)
	{
		// Process logic
	}
}
