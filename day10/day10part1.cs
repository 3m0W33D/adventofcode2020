using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class solution {
    public static void Main () {
        string input;
        var adapters = new SortedSet<int>();
        var diff = new List<int> {0,0,1};

        while(!string.IsNullOrEmpty(input = Console.ReadLine())) {
            int jolt = int.Parse(input);
            adapters.Add(jolt); 
        }
        int curr = 0;
        while (adapters.Count!=0) {
            int jolt = adapters.First();
            diff[jolt-curr-1]++;
            curr=jolt;
            adapters.Remove(adapters.First());
        }

        Console.WriteLine(diff[0]*diff[2]);
    }
}