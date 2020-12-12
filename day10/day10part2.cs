using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class solution {
    public static void Main () {
        string input;
        var adapters = new SortedSet<long>();
        var sol = new Dictionary<long,long>();
        while(!string.IsNullOrEmpty(input = Console.ReadLine())) {
            long jolt = long.Parse(input);
            adapters.Add(jolt); 
        }
        // Gave up and looked at solutions :(
        sol.Add(0,1);
        foreach (var i in adapters) {
            // Console.WriteLine(string.Join("\n",sol));
            // Console.WriteLine();
            if(!sol.ContainsKey(i)) sol.Add(i,0);
            if(sol.ContainsKey(i-1)) sol[i]+= sol[i-1];
            if(sol.ContainsKey(i-2)) sol[i]+= sol[i-2];
            if(sol.ContainsKey(i-3)) sol[i]+= sol[i-3];
        }
        Console.WriteLine(sol[adapters.Max()]);
    }
}