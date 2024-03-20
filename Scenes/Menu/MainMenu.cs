using Godot;
using System;

public partial class MainMenu : Control
{




private void _on_start_pressed()
{
	GetTree().ChangeSceneToFile("res://Scenes/root.tscn");
}


private void _on_options_pressed()
{
	GetTree().ChangeSceneToFile("res://Scenes/options.tscn");
}


private void _on_quit_pressed()
{
	GetTree().Quit();
}

}
