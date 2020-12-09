using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class solution {
    public static int dfs (Dictionary<string,Dictionary<string,int>> AM, int prev, string start) {
        int ans = 0,acc = 0;
        if (AM.ContainsKey(start)){
            AM[start].ToList().ForEach(c => {
              acc += dfs(AM,c.Value,c.Key);
              ans += c.Value;
          });
        }
        return ((ans+acc)*prev);
    }
    public static void Main() {
        var AM = new Dictionary<string,Dictionary<string,int>>();
        string input;
        while(!string.IsNullOrEmpty(input = Console.ReadLine())) {
            var cap = Regex.Match(input,@"([a-z]+) ([a-z]+) bag");
            var parent = cap.Groups[1].Value + " " + cap.Groups[2].Value;
            var matches = Regex.Matches(input,@"(\d+) ([a-z]+) ([a-z]+) bag");
            for (var i = 0; i < matches.Count; i++) {
                // Console.WriteLine(matches[i].Value);
                Dictionary<string,int> temp;
                if (AM.TryGetValue(parent,out temp)) {
                    temp.Add(matches[i].Groups[2].Value + " " + matches[i].Groups[3].Value,int.Parse(matches[i].Groups[1].Value));
                }
                else {
                    if (matches[i].Value == "no other bag") continue;
                    temp = new Dictionary<string, int>();
                    AM.Add(parent,temp);
                    AM[parent].Add(matches[i].Groups[2].Value + " " + matches[i].Groups[3].Value,int.Parse(matches[i].Groups[1].Value));
                }
            }
        }
        Console.WriteLine(dfs(AM,1,"shiny gold"));
        
    }
}