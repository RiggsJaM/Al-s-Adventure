using Godot;
using System;

public partial class main_menu : Control
{
    public void _on_play_pressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/node_2d.tscn");
    }

    public void _on_quit_pressed()
    {
        GetTree().Quit();
    }
}
