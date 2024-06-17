using Godot;
using System;
using System.Collections.Generic;
public partial class utils : Node2D
{
    public static List<string> txt_to_list(string path){
        List<string> list = new List<string>();
        using var file = Godot.FileAccess.Open(path, Godot.FileAccess.ModeFlags.Read);
        
        if (file != null){
            while(!file.EofReached()){
                string line = file.GetLine();
                list.Add(line);
            }
        }           
        else{
            GD.Print("File not found: " + path);
        }
        return list;
    }
}
