using System;
using System.Linq;
using System.Collections.Generic;

public class solution {
    public static void Main () {
        var ans =0;
        string input;
        while (!string.IsNullOrEmpty(input = Console.ReadLine())){
            var testcase = input.Split(':');
            var condition = testcase[0].Trim().Split(' ');
            var letter = char.Parse(condition[1]);
            var first  = int.Parse(condition[0].Split('-')[0])-1;
            var second = int.Parse(condition[0].Split('-')[1])-1;
            var result = testcase[1].Trim();
            if ((result[first]==letter && result[second]!=letter) || (result[first]!=letter && result[second]==letter)){
                ans++;
            }
        }
        Console.WriteLine(ans);
    }
}