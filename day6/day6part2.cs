using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class solution {
    public static void Main() {
        int counter = 1,total = 0;
        var questions = new HashSet<char>();
        while (counter <2){
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) {
                if (questions.Count != 0)
                    total += questions.Count;
                questions.Clear();
                counter++;
            }
            else {
                if (questions.Count == 0 && counter == 1)
                    questions.UnionWith(input.ToCharArray().ToList());
                else
                    questions.IntersectWith(input.ToCharArray().ToList());
                counter = 0;
            }
        }
        Console.WriteLine(total);
    }
 }