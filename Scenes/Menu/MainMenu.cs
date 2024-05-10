using Godot;
using System;

public partial class MainMenu : Control
{
	private PackedScene _transitionScene; 
	private AnimationPlayer _transitionAnimationPlayer;
	
	public override void _Ready()
	{
		GetNode<Button>("MarginContainer/VBoxContainer/ButtonsVbox/Start").GrabFocus();
		_transitionScene = (PackedScene)ResourceLoader.Load("res://Scenes/scene_transition.tscn");
		Node transitionInstance = _transitionScene.Instantiate(); 
		_transitionAnimationPlayer = transitionInstance.GetNode<AnimationPlayer>("AnimationPlayer"); 
		AddChild(transitionInstance);
	}

	private async void _on_start_pressed()
	{
		_transitionAnimationPlayer.Play("Dissolve");
		await ToSignal(_transitionAnimationPlayer, "animation_finished");
		GetTree().ChangeSceneToFile("res://Scenes/Levels/level_1.tscn");
	}

	private void _on_options_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/Menu/options(remake).tscn");
	}

	private void _on_quit_pressed()
	{	
		GetTree().Quit();
	}
}
