using Godot;
using System;

public partial class Video : TabBar
{

	private bool languageSet = false;



public override void _Ready()
{
	
}

private void _on_fullscreen_toggled(bool toggled_on)
{
	if (toggled_on)
		{
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
			
		}
		else
		{
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
			
			
		}
		
		
	}



private void _on_borderless_toggled(bool toggled_on)
{
	DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.Borderless, toggled_on);
	
	
		
}

//is this even needed, come back later
private void _on_vsync_item_selected(int index)
{
	
	}



private void _on_return_home_pressed()
{
	GetTree().ChangeSceneToFile("res://Scenes/Menu/MainMenu.tscn");
	
}



private void _on_language_item_selected(long index)
{
		if (index == 0)
		{
			TranslationServer.SetLocale("en");
		}
		else if (index == 1)
		{
			TranslationServer.SetLocale("zh");
		}
	}

}


