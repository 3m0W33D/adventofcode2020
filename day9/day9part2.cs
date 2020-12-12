using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class solution {
    public static void Main () {
        string buff;
        long error=0;
        var nums = new List<long>();
        var allnums = new List<long>();
        var lookup = new HashSet<long>();
        while(!string.IsNullOrEmpty(buff = Console.ReadLine())) {
            long input = long.Parse(buff);
            if (nums.Count < 25) {
                nums.Add(input);
                lookup.Add(input);
            }
            else {
                var counter = nums.Where(x => lookup.Contains(input-x)).ToList();
                if(counter.Count == 0) {
                    error = input;
                    break;
                }
                else {
                    lookup.Remove(nums.First());
                    nums.Remove(nums.First());
                    lookup.Add(input);
                    nums.Add(input);
                }
            }
            allnums.Add(input);
        }

        for (var i=0; i<allnums.Count;i++) {
            var connums = new SortedSet<long>();
            connums.Add(allnums[i]);
            long sum = allnums[i];
            foreach (var j in allnums.Skip(i+1)) {
                sum += j;
                connums.Add(j);
                if (sum > error) break;
                else if(sum == error) {
                    Console.WriteLine(connums.Min()+connums.Max());
                }
            }
        }
    }
}