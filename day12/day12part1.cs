using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public class solution {
    static int y = 0,x = 0;
    static Dictionary<char,int> dv = new Dictionary<char,int> () {
            {'N',1},
            {'E',1},
            {'S',-1},
            {'W',-1}
        }; 
    static int mod(int k, int n) {  return ((k %= n) < 0) ? k+n : k;  }
    public static void movedirection (char command,int value) {
            switch (command) {
            case 'N':
            case 'S' :
                y += dv[command]*value;
                break;
            case 'E':
            case 'W':
                x += dv[command]*value;
                break;
        }
    }
    public static void Main() {
        var file = new StreamReader(@"input.txt");
        string line;
        var td = new Dictionary<char,int> (){
            {'L',-1},
            {'R',1}
        };
        char d = 'E';
        while(!string.IsNullOrEmpty(line = file.ReadLine())) {
            var command = line[0];
            var value = int.Parse(line.Substring(1));
            switch (command) {
                case 'N':
                case 'S':
                case 'E':
                case 'W':
                    movedirection(command,value);
                    break;
                case 'L':
                case 'R':
                    var keys = dv.Keys.ToList();
                    var curd = keys.IndexOf(d);
                    d = keys[mod((curd + value/90*td[command]),keys.Count)];
                    break;
                case 'F':
                    movedirection(d,value);
                    break;
            }

        }
        Console.WriteLine(Math.Abs(x)+Math.Abs(y));
    }
}