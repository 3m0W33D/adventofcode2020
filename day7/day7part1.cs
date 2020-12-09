using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class solution {
    public static void dfs (Dictionary<string,HashSet<string>> AM, HashSet<string> found, string start) {
        if (AM.ContainsKey(start)){
            AM[start].ToList().ForEach(c => {
              found.Add(c);
              dfs(AM,found,c);
          });
        }
    }
    public static void Main() {
        var AM = new Dictionary<string,HashSet<string>>();
        var found = new HashSet<string>();
        string input;
        while(!string.IsNullOrEmpty(input = Console.ReadLine())) {
            var matches = Regex.Matches(input,@"([a-z]+) ([a-z]+) bag");
            var parent = matches[0].Value;
            for (var i = 1; i<matches.Count; i++) {
                // Console.WriteLine(matches[i].Value);
                HashSet<string> temp;
                if (AM.TryGetValue(matches[i].Value,out temp)) {
                    temp.Add(parent);
                }
                else {
                    if (matches[i].Value == "no other bag") continue;
                    temp = new HashSet<string> ();
                    AM.Add(matches[i].Value,temp);
                    AM[matches[i].Value].Add(parent);
                }
            }
        }
        dfs(AM,found,"shiny gold bag");
        Console.WriteLine(found.Count);
    }
}