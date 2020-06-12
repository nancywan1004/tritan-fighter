# Tritan Fighter
## Description
This is a special color mining game designed for people with blue-color recognition weakness, which was written in C# and Unity. Here are a few features that are live so far:

- We have a grid filled with four different colors: light blue, light pink, dark blue and dark pink.
- Clicking on a square/patch will make it disappear in the grid and so do its "neighbours" having the same color as itself. These "neighbours" are detected through a DFS traversal algorithm.
- In the mean time, the "neighbours" with different colors will change their current color to one of the other three colors randomly.
- The more squares you remove, the more points you get. AND you will get to reveal the gems beneath it!
- However, we use a timer to make the game more tense, yet more fun as a nature of games. 

Hope you enjoy! 😉

## Demo
Here is a quick demo of how it works:

![Tritan Fighter Game Demo v.1.0](Demo/tritan_fighter_demo.GIF)
