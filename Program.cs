using leetcode_csharp.DataStructure.Array;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var nums1 = new int[] { 1, 3 };
var nums2 = new int[] { 2 };
ArrayMain main = new ArrayMain();
var result = main.FindMedianSortedArrays(nums1, nums2);
Console.WriteLine($"result:{result}");