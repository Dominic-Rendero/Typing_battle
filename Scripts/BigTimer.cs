using Godot;
using System;

public partial class BigTimer : Timer{
	private Sprite2D fireball;
	private TextureProgressBar enemyHealth;
	public override void _Ready(){
		enemyHealth = GetNode<TextureProgressBar>("/root/Node2D/char2/EnemyHealthBar");
		fireball = GetNode<Sprite2D>("/root/Node2D/char1/fireball");
	}
	private void _on_timeout(){
			fireball.Visible = false;
			enemyHealth.Value -= 10;
	}
}
