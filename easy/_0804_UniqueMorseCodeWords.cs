// 804. Unique Morse Code Words

public class Solution
{
    private string[] NameTable = {".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};

    public int UniqueMorseRepresentations(string[] words)
    {
        HashSet<string> hashSet = new HashSet<string>();

        foreach (string word in words) 
        {
            var morse = new string("");
            foreach (var w in word) 
            {
                var str = NameTable[(int)w - (int)('a')];
                morse += str;
            }

            hashSet.Add(morse);

        }


        return hashSet.Count;
    }
}