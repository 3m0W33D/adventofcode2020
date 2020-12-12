using System;
using System.Linq;
using System.Collections.Generic;
public class solution {
    public static void Main() {
        string input;
        var grid = new List<List<char>>();
        int [] dy = {-1, 0, 1, -1, 1, -1, 0, 1};
        int [] dx = {-1, -1, -1, 0, 0, 1, 1, 1};
        while(!string.IsNullOrEmpty (input = Console.ReadLine())) {
            grid.Add(input.ToCharArray().ToList());
        }
        int term = 0;
        while(term != grid.Count) {
            var newgrid = grid.Select(i => i.ToList()).ToList();
            term = 0;
            for (var y = 0; y < grid.Count; y++) {
                for (var x = 0; x < grid[y].Count; x++) {
                    if (grid[y][x] == 'L' || grid[y][x] == '#') {
                        int counter = 0;
                        for (var j = 0; j<dy.Length;j++) {
                            var mul = 1;
                            var ny = y + dy[j]*mul;
                            var nx = x + dx[j]*mul;
                            while (ny >= 0 && ny < grid.Count && nx >= 0 && nx < grid[y].Count) {
                                if(grid[ny][nx] == '#') {
                                    counter++;
                                    break;
                                }
                                else if(grid[ny][nx] == 'L') break;
                                mul++;
                                ny = y + dy[j]*mul;
                                nx = x + dx[j]*mul;
                            }
                        }
                        if(grid[y][x] == 'L' && counter == 0) newgrid[y][x] = '#';
                        else if (grid[y][x] == '#' && counter >= 5) newgrid[y][x] = 'L';
                    }
                }
            }
            for (var i=0; i < grid.Count;i ++) {
                if (grid[i].SequenceEqual(newgrid[i])) {
                    term++;
                }
            }
            grid = newgrid;
        }
        Console.WriteLine(grid.Aggregate(0,(sum,r) => sum + r.Where(c => c == '#').ToList().Count));
    }
}