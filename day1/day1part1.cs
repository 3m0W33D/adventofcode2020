using System;
using System.Linq;
using System.Collections.Generic;
public class solution {
    public static void Main() {
        var nums = new HashSet<int>();
        string input;
        while(!string.IsNullOrEmpty(input = Console.ReadLine())){
            var num = int.Parse(input);
            if (!nums.Contains(2020-num)) {
                nums.Add(num);
            }
            else {
                Console.WriteLine(num*(2020-num));
                break;
            }
        }
    }
}