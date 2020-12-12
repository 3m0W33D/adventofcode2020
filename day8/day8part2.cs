using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class solution {
    
    public static int SwapOP (List<Tuple<string,int>> instruct, HashSet<int> visited, int index, int acc) {
        if (instruct[index].Item1 == "jmp")
            instruct[index] = Tuple.Create("nop",instruct[index].Item2);
        else
            instruct[index] = Tuple.Create("jmp",instruct[index].Item2);
        
        for (var i = index; i < instruct.Count; i++) {
            var temp = instruct[i];

            if (visited.Contains(i)){
                acc = -1;
                break;
            }
            else
                visited.Add(i);
            
            switch(temp.Item1) {
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
        return acc;
        
    }

    public static void Main() {
        string input;
        var instruct = new List<Tuple<string,int>>();
        var ran  = new HashSet<int>();
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
            var tempi = new List<Tuple<string,int>>(instruct);
            var tempu = new HashSet<int>(ran);
            if (temp.Item1 == "nop" || temp.Item1 == "jmp") {
            int val = SwapOP(tempi,tempu,i,acc);
                if (val > 0) {
                    acc=val;
                    break;
                }
            }
 
            if (ran.Contains(i))
                break;
            else
                ran.Add(i);

            switch(temp.Item1) {
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