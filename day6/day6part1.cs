using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class solution {
    public static void Main() {
        int counter = 0,total=0;
        var questions = new HashSet<char>();
        while (counter <2){
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) {
                if (questions.Count != 0)
                    total+=questions.Count;
                questions.Clear();
                counter++;
            }
            else {
                questions.UnionWith(input.ToCharArray().ToList());
                counter = 0;
            }
        }
        Console.WriteLine(total);
    }
 }