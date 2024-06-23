using Godot;
using System;
using System.Collections.Generic;
public partial class p1input : LineEdit{
    //Lists to store target words/sentences
    private List<string> words = new List<string>();
    private List<string> sentences = new List<string>();
    private Label wordlabel;
    private LineEdit inputbox;
    private Line2D hitmarker;
    private Timer hittimer;
    private Label sentencelabel;
    private Sprite2D bighit;
    private Timer bigtimer;
    private TextureProgressBar p2health;
    
    public override void _Ready(){
        GD.Print("start ready");
        wordlabel = GetNode<Label>("/root/Node2D/char1/display_word");
        sentencelabel =  GetNode<Label>("/root/Node2D/char1/display_sentence");
        inputbox = GetNode<LineEdit>("/root/Node2D/char1/input");
        hitmarker = GetNode<Line2D>("/root/Node2D/char1/hitmarker");
        hittimer = GetNode<Timer>("/root/Node2D/char1/hitmarker/timer");
        
        bighit = GetNode<Sprite2D>("/root/Node2D/char1/fireball");
        bigtimer = GetNode<Timer>("/root/Node2D/char1/fireball/BigTimer");
        
        words = utils.txt_to_list("res://rand_words.txt");
        sentences = utils.txt_to_list("res://rand_sentences.txt");
        
        p2health = GetNode<TextureProgressBar>("/root/Node2D/char2/p2healthbar");
        
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
                p2health.Value -= 1;
                hittimer.Start();
            }
            else if((sentencelabel.Text == inputbox.Text) && (bighit.Visible == true)){
                GetRandomSentence();
                bighit.Visible = false;
            }
            else if(sentencelabel.Text == inputbox.Text){
                GetRandomSentence();
                bighit.Visible = true;
                bigtimer.Start();
            }

            inputbox.Text = "";
        }
    }
}

