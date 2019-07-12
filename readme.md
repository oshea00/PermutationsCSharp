# Old Problem New C# Features!

Yes, we can write code like this now in C# 

```
////////////////////////////////////////////////
// A Recursive solution to permutations       //
// Note: new tuple swap we can do now in C#!   //
// Also, new local functionss!                //
////////////////////////////////////////////////
List<string> Perms(string word) {
    var perms = new List<string>();

    void PermsHelp(char[] a,int start, int end) {
        if (start == end)
        {
            perms.Add(new string(a));
            return;
        }
        for (int i=start; i<end; i++) {
            (a[i], a[start]) = (a[start], a[i]);
            PermsHelp(a, start + 1, end);
            (a[i], a[start]) = (a[start], a[i]);
        }
    }

    PermsHelp(word.ToArray(),0,word.Length);
    return perms;
}
```

