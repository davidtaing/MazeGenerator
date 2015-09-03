# Maze-Generator
Recursive Backtracker Algorithm in C#
This program was created for an assignment at school. I was tasked to create a DLL that could be of use in a gaming project.

How it works:
1. Choose a starting point in the field.

2. Randomly choose a wall at that point and carve a passage through to the adjacent cell, but only if the adjacent cell has not been visited yet. This becomes the new current cell.

3. If all adjacent cells have been visited, back up to the last cell that has uncarved walls and repeat.

4. The algorithm ends when the process has backed all the way up to the starting point.


Visit: http://weblog.jamisbuck.org/2010/12/27/maze-generation-recursive-backtracking for more information.

In my implementation, the field is a 2d array containing "Cells" that contain boolean flags for each wall and if it has been visited.
