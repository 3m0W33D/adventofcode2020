using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

/*
This code doesnt work its here for the memoriees for toture
*/
public class solution {
    static int y = 0,x = 0,wx=10,wy=1; 
    static char d = 'E',dl='N';
    static Dictionary<char,int> dv = new Dictionary<char,int> () {
            {'N',1},
            {'E',1},
            {'S',-1},
            {'W',-1}
        }; 
    static int mod(int k, int n) {  return ((k %= n) < 0) ? k+n : k;  }
    static void movedirection (char command,int value) {
            switch (command) {
            case 'N':
            case 'S' :
                wy += dv[command]*value;
                break;
            case 'E':
            case 'W':
                wx += dv[command]*value;
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
                    dl = keys[mod((curd -1 + value/90*td[command]),keys.Count)];
                    if( value/90 %2 != 0) {
                        var tempx = wx;
                        wx = wy;
                        wy = tempx;
                        if(d == 'S' )
                            wy = -Math.Abs(wy);
                        else if (d == 'W')
                            wx = -Math.Abs(wx);
                        else if (d == 'N')
                            wy = Math.Abs(wy);
                        else 
                            wx = Math.Abs(wx);

                        if(dl == 'S')
                            wy = -Math.Abs(wy);
                        else if (dl == 'W')
                            wx = -Math.Abs(wx);
                        else if (dl == 'N')
                            wy = Math.Abs(wy);
                        else 
                            wx = Math.Abs(wx);
                    }
                    else if (value/90 == 2) {
                        wy = -wy;
                        wx = -wx;
                    }
                    break;
                case 'F':
                    x += wx*value;
                    y += wy*value;
                break;
            }
            Console.WriteLine(d+"x-> "+wx+" y-> "+wy);
            Console.WriteLine(x+" "+y);
        }
        Console.WriteLine(Math.Abs(x)+Math.Abs(y));
    }
}