using Godot;
using System;
using System.Collections.Generic;
public partial class input : LineEdit{
    private List<string> words = new List<string>();
    private List<string> sentences = new List<string>();
    private Label wordlabel;
    private LineEdit inputbox;
    private Line2D hitmarker;
    private Timer hittimer;
    private Label sentencelabel;
    private Sprite2D bighit;
    
    public override void _Ready(){
        GD.Print("start ready");
        wordlabel = GetNode<Label>("/root/Node2D/char1/display_word");
        sentencelabel =  GetNode<Label>("/root/Node2D/char1/display_sentence");
        inputbox = GetNode<LineEdit>("/root/Node2D/char1/input");
        hitmarker = GetNode<Line2D>("/root/Node2D/char1/hitmarker");
        hittimer = GetNode<Timer>("/root/Node2D/char1/hitmarker/timer");
        
        bighit = GetNode<Sprite2D>("/root/Node2D/char1/fireball");
        
        words = utils.csv_to_list("res://rand_words.csv");
        sentences = utils.csv_to_list("res://rand_sentences.csv");
        GetRandomWord();
        GetRandomSentence();
    }
    private void GetRandomWord(){
        GD.Randomize();
        Random rand = new Random();
        int i = rand.Next(words.Count);
        var randword = words[i];
        wordlabel.Text = randword;
    } 
    private void GetRandomSentence(){
        GD.Randomize();
        Random rand = new Random();
        int i = rand.Next(sentences.Count);
        var randsen = sentences[i];
        sentencelabel.Text = randsen;
    } 
    
    public override void _Input(InputEvent @event){
        if (@event.IsActionPressed("ui_accept")){
            if(wordlabel.Text == inputbox.Text){
                GetRandomWord();
                hitmarker.Visible = true;
                hittimer.Start();
            }
            if(sentencelabel.Text == inputbox.Text){
                GetRandomSentence();
                bighit.Visible = true;
            }
            inputbox.Text = "";
        }
    }
}

