using Godot;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
public partial class display_word : Label{
    private List<string> words = new List<string>();
    private Label wordlabel;
    private LineEdit input;
    private Line2D hitmarker;
    private Timer hittimer;
    
    public override void _Ready(){
        GD.Print("start ready");
        wordlabel = GetNode<Label>("/root/Node2D/char1/display_word");
        input = GetNode<LineEdit>("/root/Node2D/char1/input");
        hitmarker = GetNode<Line2D>("/root/Node2D/char1/hitmarker");
        hittimer = GetNode<Timer>("/root/Node2D/char1/hitmarker/timer");
        
        words = utils.csv_to_list("res://rand_words.csv");
        GetRandomWord();
    }
    private void GetRandomWord(){
        GD.Randomize();
        Random rand = new Random();
        int i = rand.Next(words.Count);
        var randword = words[i];
        wordlabel.Text = randword;
    } 
    public override void _Input(InputEvent @event){
        if (@event.IsActionPressed("ui_accept")){
            if(wordlabel.Text == input.Text){
                GetRandomWord();
                hitmarker.Visible = true;
                hittimer.Start();
            }
            input.Text = "";
        }
    }
}

