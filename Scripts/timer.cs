using Godot;
using System;

public partial class timer : Timer{
    private Line2D hitmarker;
    public override void _Ready(){
        hitmarker = GetNode<Line2D>("/root/Node2D/char1/hitmarker");
    }
    private void _on_timeout(){
        GD.Print("on timeout start");
        hitmarker.Visible = false;
    }
}



