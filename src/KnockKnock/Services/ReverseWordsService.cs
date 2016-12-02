using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnock.Services 
{
    public class ReverseWordsService:IReverseWordsService
    {
        public string ReverseWords(string sentence)
        {
            if(String.IsNullOrWhiteSpace(sentence))
            {
                return String.Empty;
            }
            var tempstr = new Stack<char>();
            var outstr = new StringBuilder();
            foreach(char c in sentence)
            {
                if(!char.IsWhiteSpace(c)){
                    tempstr.Push(c);
                }
                else
                {
                    if(tempstr.Count > 0) 
                    {
                        outstr.Append(tempstr.ToArray());
                        tempstr.Clear();
                    }
                    outstr.Append(c);
                }
            }
            if(tempstr.Count > 0)
            {
                outstr.Append(tempstr.ToArray());
            }

            return outstr.ToString();
        }
    }

}