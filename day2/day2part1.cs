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
            var lower  = int.Parse(condition[0].Split('-')[0]);
            var upper = int.Parse(condition[0].Split('-')[1]);
            var result = testcase[1].Trim().ToCharArray().ToList().Where(i => i==letter).ToList();
            if (lower <= result.Count && result.Count <= upper){
                ans++;
            }
        }
        Console.WriteLine(ans);
    }
}