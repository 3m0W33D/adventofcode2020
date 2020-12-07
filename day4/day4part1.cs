using System;
using System.Linq;
using System.Collections.Generic;

public class solution {

    public static void Main() {
        string buff ="",input;
        int i=0,ans=0;
         while (i < 2) {
             input = Console.ReadLine();
             if (string.IsNullOrEmpty(input)) {
                 if (string.IsNullOrEmpty(buff)) break; 
                var dict = buff.Trim().Split(' ').ToList().Select(ent => ent.Trim().Split(':')[0]).ToHashSet();
                 if((dict.Count >= 7 && !dict.Contains("cid")) || dict.Count>=8){
                     ans++;
                 }
                 buff="";
                 i++;
             }
             else {
                 buff+=" "+input.Trim();
                 i=0;
             }
        }
        Console.WriteLine(ans);
    }
}