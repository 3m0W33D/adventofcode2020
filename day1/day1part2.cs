using System;
using System.Linq;
using System.Collections.Generic;
public class solution {
    public static void Main() {
        var nums = new HashSet<int>();
        string input;
        while(!string.IsNullOrEmpty(input = Console.ReadLine())){
            var num = int.Parse(input);
            var ans = nums.Where(i => (2020-i-num)>0 && nums.Contains(2020-i-num)).ToList();
            if (ans.Count == 0 ) {
                nums.Add(num);
            }
            else {
                Console.WriteLine(num*ans[0]*(2020-num-ans[0]));
                break;
            }
        }
    }
}