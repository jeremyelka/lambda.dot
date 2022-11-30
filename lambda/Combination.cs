using System;
using System.IO;
using System.Text;
using Amazon.Lambda.Core;

namespace example.lambda
{
    public class LambdaHandler
    {

        static List<List<int>> comb;
        static bool[] alreadyUsed;

        public Stream Combination(int input,int index)
        {

            return new MemoryStream(CreateAndReturnPromotation(input,index));

        }

        static List<int> CreateAndReturnPromotation(int length , int indexRes)
        {
            
            int[] arr = new int[length];
            
            for(var i=0;i<length;i++){
                arr[i]=i+1;
            }

            alreadyUsed = new bool[arr.Length];
            comb = new List<List<int>>();
            List<int> rowInCombination = new List<int>();

            GetPromotation(arr, 0, rowInCombination);

            foreach (var item in comb)
            {
                foreach (var x in item)
                {
                    Console.Write(x + ",");
                }
                Console.WriteLine("");
            }
            
            return comb[indexRes-1];
        }
        
        static void GetPromotation(int[] arr, int idx, List<int> rowInCombination)
        {

            if (idx >= arr.Length)
            {
                comb.Add(new List<int>(rowInCombination));
                return;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (!alreadyUsed[i])
                {
                    alreadyUsed[i] = true;
                    rowInCombination.Add(arr[i]);
                    GetPromotation(arr, idx + 1, rowInCombination);
                    rowInCombination.RemoveAt(rowInCombination.Count - 1);
                    alreadyUsed[i] = false;
                }
            }
        }
    }
}
