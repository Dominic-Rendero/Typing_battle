using Godot;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
public partial class display_word : Label{
    private List<string> words = new List<string>();
    private Label wordlabel;
    
    public override void _Ready(){
        GD.Print("start ready");
        wordlabel = GetNode<Label>("/root/Node2D/char1/display_word");
        words = csv_to_list("res://rand_words.csv");
        string random_word = GetRandomWord();
        wordlabel.Text = random_word;
    }
    public List<string> csv_to_list(string path){
        List<string> wordlist = new List<string>();
        using var file = Godot.FileAccess.Open(path, Godot.FileAccess.ModeFlags.Read);
        
        if (file != null){
            while(!file.EofReached()){
                string word = file.GetLine();
                wordlist.Add(word);
            }
        }           
        else
        {

            GD.Print("File not found: " + path);
        }

        return wordlist;
    }

    
    
    private string GetRandomWord(){
        GD.Randomize();
        Random rand = new Random();
        int i = rand.Next(words.Count);
        var output = words[i];
        return output;
    }
} 

