using Godot;
using System;

public partial class Timer : Godot.Timer{
	private Line2D hitmarker;
	private TextureProgressBar healthbar;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		hitmarker = GetNode<Line2D>("/root/Node2D/char2/EnemyHitmarker");
		healthbar = GetNode<TextureProgressBar>("/root/Node2D/char1/PlayerHealthBar");
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		healthbar.Value -= 1;
	}
}
