using Godot;
using System;

public partial class options : Control
{




private void _on_back_pressed()
{
	GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");
}




private void _on_return_home_pressed()
{
	GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");
}
}
