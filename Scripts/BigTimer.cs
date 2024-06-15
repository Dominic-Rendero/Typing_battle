using Godot;
using System;

public partial class BigTimer : Timer{
    private Sprite2D fireball;
    public override void _Ready(){
        fireball = GetNode<Sprite2D>("/root/Node2D/char1/fireball");
    }
    private void _on_timeout(){
            GD.Print("on timeout start for firball");
            fireball.Visible = false;
    }
}
