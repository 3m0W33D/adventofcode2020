using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class solution {
    public static void Main () {
        string buff;
        var nums = new List<int>();
        var lookup = new HashSet<int>();
        while(!string.IsNullOrEmpty(buff = Console.ReadLine())) {
            int input = int.Parse(buff);
            if (nums.Count < 25) {
                nums.Add(input);
                lookup.Add(input);
            }
            else {
                var counter = nums.Where(x => lookup.Contains(input-x)).ToList();
                if(counter.Count == 0) {
                    Console.WriteLine(input);
                    break;
                }
                else {
                    lookup.Remove(nums.First());
                    nums.Remove(nums.First());
                    lookup.Add(input);
                    nums.Add(input);
                }
            }
        }
    }
}