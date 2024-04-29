using Godot;
using System;

public partial class level_2_gen : proc_gen
{
	private Vector2I stoneAtlas= new Vector2I(3,1);
	private Vector2I flowerAtlas=new Vector2I(3,4);
	private Vector2I grassAtlas=new Vector2I(4,1);

	public override void _Ready()
	{
		base._Ready();
		GenerateLevel(50,100, stoneAtlas, flowerAtlas, grassAtlas);
	}

	public override void _Process(double delta)
	{
	}
}
