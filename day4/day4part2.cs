using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class solution {

    public static void Main() {
        string buff ="",input;
         var ecolor = new List <string> {"amb","blu","brn","gry","grn","hzl","oth"};
        int i=0,ans=0;
         while (i < 2) {
             input = Console.ReadLine();
             if (string.IsNullOrEmpty(input)) {
                 if(string.IsNullOrEmpty(buff)) break; 
                var dict = buff.Trim().Split(' ').ToList().Where(ent => {
                    var temp = ent.Trim().Split(':');
                    switch(temp[0]) {
                        case "byr":
                            return temp[1].Length == 4 &&int.Parse(temp[1]) >= 1920 && int.Parse(temp[1]) <= 2020;
                        case "iyr": 
                            return temp[1].Length == 4 && int.Parse(temp[1]) >= 2010 && int.Parse(temp[1]) <= 2020;
                        case "eyr":
                            return temp[1].Length == 4 && int.Parse(temp[1]) >= 2020 && int.Parse(temp[1]) <= 2030;
                        case "hgt":
                            if(temp[1].Length > 5) return false;
                            var height = Regex.Match(temp[1],@"(\d+)(cm|in)");
                            if (height.Groups[2].Value == "cm") 
                                return int.Parse(height.Groups[1].Value) >= 150 && int.Parse(height.Groups[1].Value)<=193;
                            else if (height.Groups[2].Value == "in") 
                                return int.Parse(height.Groups[1].Value) >= 59 && int.Parse(height.Groups[1].Value) <= 76;
                            else 
                                return false;
                        case "hcl":
                            var color = Regex.Match(temp[1],@"#[a-f0-9]{6}");
                            return temp[1].Length == 7 && color.Success;
                        case "ecl":

                            return temp[1].Length == 3 && ecolor.Contains(temp[1]);
                        case "pid":
                            var pid = Regex.Match(temp[1],@"[0-9]{9}");
                            return temp[1].Length == 9;
                        default:
                        return true;
                    }
                }).Select(ent => ent.Trim().Split(':')[0]).ToHashSet();
                 if ((dict.Count >= 7 && !dict.Contains("cid")) || dict.Count==8){
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