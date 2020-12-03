using System;
using System.Linq;
using System.Collections.Generic;

public class solution {
    static int[] dx={1,3,5,7,1},dy={1,1,1,1,2};
    static int ans=0;
    static List<List<char>> am = new List<List<char>>();

    public static void dfs(int y, int x,int dy,int dx) {
        var ny = y+dy;
        var nx = (x+dx) % am[0].Count;
        if(ny > -1 &&  ny < am.Count) {
            if(am[ny][nx]=='#'){
                ans++;
            }
            dfs(ny,nx,dy,dx);
        }
    }
    public static void Main() {
        string input;
        long finalans =0;
        while (!string.IsNullOrEmpty(input = Console.ReadLine())){
            am.Add(input.ToCharArray().ToList());
        }
        for (var i =0;i<5;i++) {
            dfs(0,0,dy[i],dx[i]);
            if(finalans==0)
                finalans=ans;
            else
                finalans*=ans;
            ans=0;
        }
        Console.WriteLine(finalans);
    }
}