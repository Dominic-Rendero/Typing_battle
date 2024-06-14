using Godot;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
public partial class main : Node2D
{
    public List<string> csv_to_list(string path){
        List<string> wordlist = new List<string>();
        using var file = Godot.FileAccess.Open(path, Godot.FileAccess.ModeFlags.Read);
        
        if (file != null){
            while(!file.EofReached()){
                string word = file.GetLine();
                wordlist.Add(word);
            }
        }           
        else{
            GD.Print("File not found: " + path);
        }
        return wordlist;
    }
}
