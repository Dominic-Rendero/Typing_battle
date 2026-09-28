using Godot;
using System;
using System.Collections.Generic;
public partial class p1input : LineEdit{
	//Lists to store target words/sentences
	private List<string> words = new List<string>();
	private List<string> sentences = new List<string>();
	private Label wordlabel;
	private Line2D hitmarker;
	private Timer hittimer;
	private Label sentencelabel;
	private Sprite2D bighit;
	private Timer bigtimer;
	private TextureProgressBar enemyHealth;
	
	public override void _Ready(){
		GD.Print("start ready");
		wordlabel = GetNode<Label>("/root/Node2D/char1/display_word");
		sentencelabel =  GetNode<Label>("/root/Node2D/char1/display_sentence");
		hitmarker = GetNode<Line2D>("/root/Node2D/char1/hitmarker");
		hittimer = GetNode<Timer>("/root/Node2D/char1/hitmarker/timer");
		
		bighit = GetNode<Sprite2D>("/root/Node2D/char1/fireball");
		bigtimer = GetNode<Timer>("/root/Node2D/char1/fireball/BigTimer");
		
		words = utils.txt_to_list("res://rand_words.txt");
		sentences = utils.txt_to_list("res://rand_sentences.txt");
		
		enemyHealth = GetNode<TextureProgressBar>("/root/Node2D/char2/EnemyHealthBar");
		
		GetRandomWord();
		GetRandomSentence();
		TextSubmitted += OnTextSubmitted;
		CallDeferred("grab_focus");
	}
	private void GetRandomWord(){
		GD.Print("GetRandomWord was run");
		GD.Randomize();
		Random rand = new Random();
		int i = rand.Next(words.Count);
		var randword = words[i];
		wordlabel.Text = randword;
	} 
	private void GetRandomSentence(){
		GD.Print("GetRandomSentence was run");
		GD.Randomize();
		Random rand = new Random();
		int i = rand.Next(sentences.Count);
		var randsen = sentences[i];
		sentencelabel.Text = randsen;
	} 
	
	private void OnTextSubmitted(string submitted){
		if(wordlabel.Text == submitted){
			GetRandomWord();
			hitmarker.Visible = true;
			enemyHealth.Value -= 1;
			hittimer.Start();
		}
		else if((sentencelabel.Text == submitted) && (bighit.Visible == true)){
			GetRandomSentence();
		}
		else if(sentencelabel.Text == submitted){
			GetRandomSentence();
			bighit.Visible = true;
			bigtimer.Start();
		}
		Clear();
		CallDeferred("grab_focus");
	}
}
