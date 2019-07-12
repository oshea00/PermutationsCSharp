using System;
using System.Collections.Generic;
using System.Linq;
namespace permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(string.Join(",",p.Perms("bing")));
            Console.WriteLine(string.Join(",",p.PermsI("bing")));
        }

        ////////////////////////////////////////////////
        // A Recursive solution to permutations       //
        // Note new tuple swap we can do now in C#!   //
        ////////////////////////////////////////////////
        void PermsHelp(char[] a,int start, int end, List<string> perms) {
            if (start == end)
            {
                perms.Add(new string(a));
                return;
            }
            for (int i=start; i<end; i++) {
                (a[i], a[start]) = (a[start], a[i]);
                PermsHelp(a, start + 1, end, perms);
                (a[i], a[start]) = (a[start], a[i]);
            }
        }

        List<string> Perms(string word) {
            var perms = new List<string>();
            PermsHelp(word.ToArray(),0,word.Length,perms);
            return perms;
        }

        ////////////////////////////////////////////////
        // Implements permutation iteratively using   //
        // queue - could be stack-based as well       //
        // or even a mixture - only affects perm      //
        // ordering.                                  //
        // Iteratively inserts the next letter in a   //
        // progressively larger list of intermediate  //
        // smaller permutations of the initial word.  //
        ////////////////////////////////////////////////
        List<string> PermsI(string word)
        {
            if (string.IsNullOrEmpty(word))
                return new List<string>();
                
            var a = word.ToArray();
            var queue = new Queue<List<char>>();
            queue.Enqueue(new List<char>());
            // for each letter in word
            for (int i=0; i<word.Length; i++) {
                var newqueue = new Queue<List<char>>();
                // for each queue item
                while (queue.Count()>0) {
                    var item = queue.Dequeue();
                    var itemlen = item.Count();
                    // insert word[i] letter into item at itemlen+1 places
                    for (var j=0; j<itemlen+1; j++) {
                        var itemcopy = new List<char>(item);
                        itemcopy.Insert(j,word[i]);
                        newqueue.Enqueue(itemcopy);
                    }
                }
                queue = newqueue;
            }
            
            return queue.Select(s=> new string(s.ToArray())).ToList();	
        }
    }
}
