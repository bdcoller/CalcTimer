// Code developed in class, 13 September 2023
using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int n = 800000;   // number of random numbers to generate
        double[,] numbers;
        Stopwatch timer = new Stopwatch();

        numbers = GenRandomNumbers(n);

        timer.Start();
        AddNumbers(numbers, n);
        timer.Stop();
        Console.WriteLine("Additions");
        Console.WriteLine("Elapsed time = " + 
            timer.ElapsedMilliseconds + " ms   " +
            timer.ElapsedTicks + " ticks\n");
        float addTicks = (float)timer.ElapsedTicks;
        
        timer.Restart();
        MultiplyNumbers(numbers, n);
        timer.Stop();
        Console.WriteLine("Multiplications");
        Console.WriteLine("Elapsed time = " + 
            timer.ElapsedMilliseconds + " ms   " +
            timer.ElapsedTicks + " ticks\n");
        float multTicks = (float)timer.ElapsedTicks;

        Console.WriteLine("Ratio = " + addTicks/multTicks);
    }

    // Function to generate an array of random numbers
    static double[,] GenRandomNumbers(int count)
    {
        Random rand = new Random(); // instantiate random number generator
        double[,] num = new double[count,3]; // make array
        for(int i=0; i<count; ++i){
            num[i,0] = 10000.0*rand.NextDouble(); // fill in elements of array
            num[i,1] = 10000.0*rand.NextDouble();
        }

        return num;  // returns reference to array
    }

    // Function that adds numbers in the supplied 2d array
    static void AddNumbers(double[,] nums, int count)
    {
        int i;
        for(i=0; i<count; ++i){
            nums[i,2] = nums[i,0] + nums[i,1];
        }
    }

    // Function that adds numbers in the supplied 2d array
    static void MultiplyNumbers(double[,] nums, int count)
    {
        int i;
        for(i=0; i<count; ++i){
            nums[i,2] = nums[i,0] * nums[i,1];
        }
    }
}
