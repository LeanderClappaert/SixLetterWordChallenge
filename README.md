# 6 letter words
There's a file in the root of the repository, input.txt, that contains words of varying lengths (1 to 6 characters).

Your objective is to show all combinations of those words that together form a word of 6 characters. That combination must also be present in input.txt
E.g.:  
<code>
foobar  
fo  
obar  
</code>

should result in the ouput:  
<code>
fo+obar=foobar
</code>

You can start by only supporting combinations of two words and improve the algorithm at the end of the exercise to support any combinations.

Treat this exercise as if you were writing production code; think unit tests, SOLID, clean code and avoid primitive obsession. Be mindful of changing requirements like a different maximum combination length, or a different source of the input data.

The solution must be stored in a git repo. After the repo is cloned, the application should be able to run with one command / script.

Don't spend too much time on this.

# Remarks

- Target Framework: .NET 5.0
- Works for 2-word combinations.
- You can run this program by cloning the repository and execute SixLetterWordChallenge\ReleaseExe\SixLetterWordChallenge.exe

# Update
- Works for N-word combinations now.
-- Still have to improve the performance a lot (4-letter word takes about 1m10s).
- Updated the release executable, found @ SixLetterWordChallenge\ReleaseExe\SixLetterWordChallenge.exe

# Update 2
- Improved the performance.
-- Used to take 1m10s for 4-letter words, now it takes 32s.
- Updated the release executable, found @ SixLetterWordChallenge\ReleaseExe\SixLetterWordChallenge.exe

# To do
- Performance! Takes a while to find all N-word combinations (for a 6-letter word).
-- 5-letter words take about 17m.
- More command line configuration, e.g. path to a text file, set the length of the words to be found (currently 6 only, hard-coded).
- ...
