using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public class solution {
    static int y = 0,x = 0,wx=10,wy=1; 
    public static void Main() {
        var file = new StreamReader(@"input.txt");
        string line;
      
        while(!string.IsNullOrEmpty(line = file.ReadLine())) {
            var command = line[0];
            var value = int.Parse(line.Substring(1));
            switch (command) {
                case 'N':
                    wy += value;
                    break;
                case 'S':
                    wy-=value;
                    break;
                case 'E':
                    wx += value;
                    break;
                case 'W':
                    wx -= value;
                    break;
                case 'L':
                    if (value == 90) {
                        var temp = wx;
                        wx = -wy;
                        wy = temp;

                    }
                    else if(value == 180) {
                        wx=-wx;
                        wy=-wy;
                    }
                    else if (value == 270){
                        var temp = wx;
                        wx = wy;
                        wy = -temp;
                    }
                    break;
                case 'R':
                    if (value == 90) {
                        var temp = wx;
                        wx = wy;
                        wy = -temp;

                    }
                    else if(value == 180) {
                        wx=-wx;
                        wy=-wy;
                    }
                    else if (value == 270) {
                        var temp = wx;
                        wx = -wy;
                        wy = temp;
                    }
                    break;
                case 'F':
                    x += wx*value;
                    y += wy*value;
                break;
            }
            Console.WriteLine("x-> "+wx+" y-> "+wy);
            Console.WriteLine(x+" "+y);
        }
        Console.WriteLine(Math.Abs(x)+Math.Abs(y));
    }
}