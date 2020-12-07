using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class solution {
    public static void Main() {
        var seats = new SortedSet<int>();
        string input;
        while (!string.IsNullOrEmpty(input = Console.ReadLine())){
            var rows = input.Substring(0,7).ToCharArray().ToList();
            var column = input.Substring(7,3).ToCharArray().ToList();
            int upper = 127,lower = 0;
            rows.ForEach(dir => {
               if (dir == 'F') {
                   upper -= ((upper-lower)/2)+1;
               }
               else{
                   lower += ((upper-lower)/2)+1;
               }
            //    Console.WriteLine(upper + " to " +lower);
            });
            int rowval = lower;
            upper = 7;
            lower = 0;
            column.ForEach(dir => {
               if (dir == 'L') {
                   upper -= ((upper-lower)/2)+1;
               }
               else{
                   lower += ((upper-lower)/2)+1;
               }
            //    Console.WriteLine(upper + " to " +lower);
            });
            int colval = lower;
            seats.Add(rowval * 8 + colval);
        }
        int prev = -1;
        foreach (var i in seats) {
            if (prev == -1){
                prev = i;
            }
            else {
                if ((i - prev) >1) {
                    Console.WriteLine(prev+1);
                    break;
                }
                else
                    prev=i;
            }
        }
    }
}