using System;
using System.Linq;
using System.Collections.Generic;

public class solution {
    static int ans=0,dx=3,dy=1;
    static List<List<char>> am = new List<List<char>>();

    public static void dfs(int y, int x) {
        var ny = y+dy;
        var nx = (x+dx) % am[0].Count;
        if(y > -1 &&  ny < am.Count) {
            if(am[ny][nx]=='#'){
                ans++;
            }
            dfs(ny,nx);
        }
    }
    public static void Main() {
        string input;

        while (!string.IsNullOrEmpty(input = Console.ReadLine())){
            am.Add(input.ToCharArray().ToList());
        }
        dfs(0,0);
        Console.WriteLine(ans);
    }
}