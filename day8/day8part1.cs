using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class solution {
    public static void Main() {
        string input;
        var instruct = new List<Tuple<string,int>>();
        var ran  = new HashSet<int> ();
        int acc = 0;
        while (!string.IsNullOrEmpty(input = Console.ReadLine())) {
            var splitted = input.Split(' ');
            var cmd = splitted[0].Trim();
            var num = int.Parse(splitted[1].Trim());
            var temp = Tuple.Create(cmd,num);
            instruct.Add(temp);
        }

        for (var i = 0; i < instruct.Count; i++) {
            var temp = instruct[i];
            if (ran.Contains(i))
                break;
            else
                ran.Add(i);
            
            switch(temp.Item1) {
                case "nop":
                    break;
                case "acc":
                    acc += temp.Item2;
                    break;
                case "jmp":
                    i += temp.Item2-1;
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine(acc);
    }
}